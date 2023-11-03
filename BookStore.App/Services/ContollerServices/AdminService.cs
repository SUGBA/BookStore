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

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly ICoockieService _coockeService;
        private readonly IUserRepository _userRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly INewsRepositrory _newsRepository;
        private readonly IMapper _mapper;

        public AdminService(IMapper mapper, ICoockieService coockeService, IUserRepository userRepositrory,
            IStoreRepository storeRepository, INewsRepositrory newsRepository)
        {
            _mapper = mapper;
            _coockeService = coockeService;
            _userRepository = userRepositrory;
            _storeRepository = storeRepository;
            _newsRepository = newsRepository;
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
            var users = await _userRepository.GetUsers();
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
        public async Task<AdminItemsDto<UserEntity>> UserViewModel()
        {
            var users = await _userRepository.GetUsers();

            if (users == null)
                return new AdminItemsDto<UserEntity>() { ActiveItem = new UserEntity() };
            else
                return new AdminItemsDto<UserEntity>() { Items = users, ActiveItem = new UserEntity() };
        }

        /// <summary>
        /// Получить ViewModel без выбранной книги
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<StoreEntity>> CatalogViewModel()
        {
            var items = await _storeRepository.GetStores();

            if (items == null)
                return new AdminItemsDto<StoreEntity>() { ActiveItem = new StoreEntity() };
            else
                return new AdminItemsDto<StoreEntity>()
                {
                    Items = items,
                    ActiveItem = new StoreEntity()
                    {
                        Book = new BookEntity(),
                        Department = new DepartmentEntity()
                    }
                };
        }

        /// <summary>
        /// Получить ViewModel без выбранной новости
        /// </summary>
        /// <returns></returns>
        public async Task<AdminItemsDto<NewsEntity>> NewsViewModel()
        {
            var news = await _newsRepository.GetNews();

            if (news == null)
                return new AdminItemsDto<NewsEntity>() { ActiveItem = new NewsEntity() };
            else
                return new AdminItemsDto<NewsEntity>() { Items = news, ActiveItem = new NewsEntity() };
        }

        /// <summary>
        /// Получить ViewModel с выбранным пользователем
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<UserEntity>> UserViewModel(int itemId)
        {
            var model = await UserViewModel();
            var user = await _userRepository.GetUserById(itemId);

            if (user != null)
                model.ActiveItem = user;

            return model;
        }

        /// <summary>
        /// Получить ViewModel с выбранной книгой
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<StoreEntity>> CatalogViewModel(int departmentId, int bookId)
        {
            var model = await CatalogViewModel();
            var item = await _storeRepository.GetStoreById(departmentId, bookId);

            if (item != null)
                model.ActiveItem = item;

            return model;
        }

        /// <summary>
        /// Получить ViewModel с выбранной новостью
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<AdminItemsDto<NewsEntity>> NewsViewModel(int itemId)
        {
            var model = await NewsViewModel();
            var news = await _newsRepository.GetNewsById(itemId);

            if (news != null)
                model.ActiveItem = news;

            return model;
        }
    }
}
