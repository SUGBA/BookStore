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

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly ICoockieService _coockeService;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AdminService(IUserRepository repositrory, IMapper mapper, ICoockieService coockeService)
        {
            _repository = repositrory;
            _mapper = mapper;
            _coockeService = coockeService;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public LoginUserDto CreateViewModel(string Login = "", string Password = "")
        {
            return new LoginUserDto() { Login = Login, Password = Password };
        }

        /// <summary>
        /// Авторизоваться. True - удалось авторизоваться, False - не удалось авторизоваться
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> Login(LoginUserDto model, HttpContext context)
        {
            var users = await _repository.GetUsers();
            var claimsIdentity = _coockeService.GetClaimsIdentity(model, users);
            if (claimsIdentity == null)
                return false;

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return true;
        }
    }
}
