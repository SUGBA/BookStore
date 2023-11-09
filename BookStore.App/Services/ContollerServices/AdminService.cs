using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Admin.Dto;
using BookStore.Catalog.Dto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using BookStore.App.Services.AuthServices.Interfaces;
using BookStore.Admin.Entity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using BookStore.App.Data.Consts;
using BookStore.Data.EntityDto.AdminDto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.Catalog.Entity;
using BookStore.News.Entity;
using BookStore.App.Services.ConnectionServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Connections.Features;
using BookStore.EF.Repository;
using BookStore.App.Services.FileService.Interfaces;
using System.Runtime.InteropServices;

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly IFileService _fileService;
        private readonly ICoockieService _coockeService;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<StoreEntity> _storeRepository;
        private readonly IBaseRepository<DepartmentEntity> _departmentRepository;
        private readonly IBaseRepository<NewsEntity> _newsRepository;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public AdminService(IFileService fileService, IMapper mapper, ICoockieService coockeService, IBaseRepository<UserEntity> userRepositrory,
            IBaseRepository<StoreEntity> storeRepository, IBaseRepository<NewsEntity> newsRepository, ISessionService sessionService,
            IBaseRepository<DepartmentEntity> departmentRepository)
        {
            _fileService = fileService;
            _mapper = mapper;
            _coockeService = coockeService;
            _userRepository = userRepositrory;
            _storeRepository = storeRepository;
            _newsRepository = newsRepository;
            _sessionService = sessionService;
            _departmentRepository = departmentRepository;
        }
        #region Панель авторизации
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public LoginUserDto CreateViewModel(string Login = "", string Password = "", string Message = "")
        {
            return new LoginUserDto() { Login = Login, Password = Password, Message = Message };
        }

        /// <summary>
        /// Авторизоваться. True - удалось авторизоваться, False - не удалось авторизоваться
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> Login(LoginUserDto model, HttpContext context)
        {
            var users = await _userRepository.GetAll().ToListAsync();
            if (users == null)
            {
                model.Message = UserMessageConsts.UNKNOW_USER;
                return false;
            }

            var claimsIdentity = _coockeService.GetClaimsIdentity(model, users);

            if (claimsIdentity == null)
            {
                model.Message = UserMessageConsts.UNKNOW_USER;
                return false;
            }

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return true;
        }

        #endregion

        #region Без выбранного элемента

        /// <summary>
        /// Получить ViewModel без выбранного пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<UserEntity>> UserViewModel(HttpContext context)
        {
            _sessionService.ClearSelectedItem(context);

            var items = await _userRepository.GetAll().ToListAsync();

            return CreateEmptyViewModel<UserEntity>(items, _sessionService.GetId(context));
        }

        /// <summary>
        /// Получить ViewModel без выбранной книги
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<StoreEntity>> CatalogViewModel(HttpContext context)
        {
            _sessionService.ClearSelectedItem(context);

            var items = await _storeRepository.GetAll()
                .Include(x => x.Book)
                .Include(y => y.Department)
                .ThenInclude(y => y.Manager)
                .ToListAsync();

            return CreateEmptyViewModel<StoreEntity>(items, _sessionService.GetId(context));
        }

        /// <summary>
        /// Получить ViewModel без выбранной новости
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<NewsEntity>> NewsViewModel(HttpContext context)
        {
            _sessionService.ClearSelectedItem(context);

            var items = await _newsRepository.GetAll().ToListAsync();

            return CreateEmptyViewModel<NewsEntity>(items, _sessionService.GetId(context));
        }

        #endregion

        private AdminItemsDto<T> CreateEmptyViewModel<T>(List<T> values, int selectedId) where T : class, new()
        {
            if (values == null)
                return new AdminItemsDto<T>() { ActiveItem = new T(), SelectedId = selectedId };
            else
                return new AdminItemsDto<T>() { Items = values, ActiveItem = new T(), SelectedId = selectedId };
        }

        #region С выбранным элементом
        /// <summary>
        /// Получить ViewModel с выбранным пользователем
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<UserEntity>> UserViewModel(HttpContext context, int itemId)
        {
            var items = await _userRepository.GetAll().ToListAsync();

            _sessionService.SetSelectedItem(context, itemId);

            var model = CreateEmptyViewModel<UserEntity>(items, _sessionService.GetId(context));

            var user = await _userRepository.GetById(itemId);

            if (user != null)
                model.ActiveItem = user;

            return model;
        }

        /// <summary>
        /// Получить ViewModel с выбранной книгой
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<StoreEntity>> CatalogViewModel(HttpContext context, int itemId)
        {
            var items = await _storeRepository.GetAll()
                .Include(x => x.Book)
                .Include(y => y.Department)
                .ThenInclude(y => y.Manager)
                .ToListAsync();

            _sessionService.SetSelectedItem(context, itemId);

            var model = CreateEmptyViewModel<StoreEntity>(items, _sessionService.GetId(context));

            var item = await _storeRepository.GetById(itemId, x => x.Book, p => p.Department);

            if (item != null)
                model.ActiveItem = item;

            return model;
        }

        /// <summary>
        /// Получить ViewModel с выбранной новостью
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<NewsEntity>> NewsViewModel(HttpContext context, int itemId)
        {
            var items = await _newsRepository.GetAll().ToListAsync();

            _sessionService.SetSelectedItem(context, itemId);

            var model = CreateEmptyViewModel<NewsEntity>(items, _sessionService.GetId(context));

            var news = await _newsRepository.GetById(itemId);

            if (news != null)
                model.ActiveItem = news;

            return model;
        }

        #endregion

        #region Создание/Изменение

        public async Task<AdminItemsDto<UserEntity>> ProcessUserItem(HttpContext context, AdminItemsDto<UserEntity> answer)
        {
            var selectedId = _sessionService.GetId(context);
            if (selectedId == default(int))
            {
                await _userRepository.Add(answer.ActiveItem);
            }
            else
            {
                answer.ActiveItem.Id = selectedId;
                await _userRepository.Update(answer.ActiveItem);
            }

            return await UserViewModel(context);
        }

        public async Task<AdminItemsDto<StoreEntity>> ProcessCatalogItem(HttpContext context, AdminItemsDto<StoreEntity> answer)
        {
            var department = _departmentRepository.GetAll().FirstOrDefault(x => x.Address == answer.ActiveItem.Department.Address);
            if (department == null)
                return await CatalogViewModel(context);

            _departmentRepository.Attach(department);
            answer.ActiveItem.Department = department;

            var selectedId = _sessionService.GetId(context);

            if (selectedId == default(int))
            {
                answer.ActiveItem.Book.PathToImage = await _fileService.AddAndGetPath<StoreEntity>(answer.File);
                await _storeRepository.Add(answer.ActiveItem);
            }
            else
            {
                if (answer.File is not null)
                    answer.ActiveItem.Book.PathToImage = await _fileService.AddAndGetPath<StoreEntity>(answer.File);
                answer.ActiveItem.Id = selectedId;
                await _storeRepository.Update(answer.ActiveItem);
            }

            return await CatalogViewModel(context);
        }

        public async Task<AdminItemsDto<NewsEntity>> ProcessNewsItem(HttpContext context, AdminItemsDto<NewsEntity> answer)
        {
            var selectedId = _sessionService.GetId(context);

            answer.ActiveItem.DateCreate = DateTime.UtcNow;

            if (selectedId == default(int))
            {
                answer.ActiveItem.PathToImage = await _fileService.AddAndGetPath<NewsEntity>(answer.File);
                await _newsRepository.Add(answer.ActiveItem);
            }
            else
            {
                if (answer.File is not null)
                    answer.ActiveItem.PathToImage = await _fileService.AddAndGetPath<NewsEntity>(answer.File);
                answer.ActiveItem.Id = selectedId;
                await _newsRepository.Update(answer.ActiveItem);
            }

            return await NewsViewModel(context);
        }

        #endregion
    }
}
