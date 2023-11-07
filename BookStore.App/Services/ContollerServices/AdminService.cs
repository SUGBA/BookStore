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

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly ICoockieService _coockeService;
        private readonly IBaseRepository<UserEntity> _userRepository;
        private readonly IBaseRepository<StoreEntity> _storeRepository;
        private readonly IBaseRepository<NewsEntity> _newsRepository;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public AdminService(IMapper mapper, ICoockieService coockeService, IBaseRepository<UserEntity> userRepositrory,
            IBaseRepository<StoreEntity> storeRepository, IBaseRepository<NewsEntity> newsRepository, ISessionService sessionService)
        {
            _mapper = mapper;
            _coockeService = coockeService;
            _userRepository = userRepositrory;
            _storeRepository = storeRepository;
            _newsRepository = newsRepository;
            _sessionService = sessionService;
        }

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

        /// <summary>
        /// Получить ViewModel без выбранного пользователя
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<UserEntity>> UserViewModel(HttpContext context)
        {
            _sessionService.SetCeateStatus(context);

            var items = await _userRepository.GetAll().ToListAsync();

            return CreateEmptyViewModel<UserEntity>(items);
        }

        /// <summary>
        /// Получить ViewModel без выбранной книги
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<StoreEntity>> CatalogViewModel(HttpContext context)
        {
            _sessionService.SetCeateStatus(context);

            var items = await _storeRepository.GetAll()
                .Include(x => x.Book)
                .Include(y => y.Department)
                .ThenInclude(y => y.Manager)
                .ToListAsync();

            return CreateEmptyViewModel<StoreEntity>(items);
        }

        /// <summary>
        /// Получить ViewModel без выбранной новости
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<NewsEntity>> NewsViewModel(HttpContext context)
        {
            _sessionService.SetCeateStatus(context);

            var items = await _newsRepository.GetAll().ToListAsync();

            return CreateEmptyViewModel<NewsEntity>(items);
        }

        private AdminItemsDto<T> CreateEmptyViewModel<T>(List<T> values) where T : class, new()
        {
            if (values == null)
                return new AdminItemsDto<T>() { ActiveItem = new T() };
            else
                return new AdminItemsDto<T>() { Items = values, ActiveItem = new T() };
        }

        /// <summary>
        /// Получить ViewModel с выбранным пользователем
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<UserEntity>> UserViewModel(HttpContext context, int itemId)
        {
            var items = await _userRepository.GetAll().ToListAsync();
            var model = CreateEmptyViewModel<UserEntity>(items);

            _sessionService.SetChangeStatus(context);

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
            var model = CreateEmptyViewModel<StoreEntity>(items);

            _sessionService.SetChangeStatus(context);

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
            var model = CreateEmptyViewModel<NewsEntity>(items);

            _sessionService.SetChangeStatus(context);

            var news = await _newsRepository.GetById(itemId);

            if (news != null)
                model.ActiveItem = news;

            return model;
        }
    }
}
