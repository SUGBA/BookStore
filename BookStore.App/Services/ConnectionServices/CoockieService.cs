using System.Security.Claims;
using System;
using System.Text;
using BookStore.Admin.Dto;
using BookStore.Admin.Entity;
using BookStore.App.Services.AuthServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BookStore.App.Services.AuthServices
{
    public class CoockieService : ICoockieService
    {
        private readonly IConfiguration _configuration;

        public CoockieService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Авторизация пользователя. Null - не удалось авторизоваться
        /// </summary>
        /// <param name="model"> DTO из вьюхи</param>
        /// <param name="users"> Список пользователей </param>
        /// <returns></returns>
        public ClaimsIdentity? GetClaimsIdentity(LoginUserDto model, List<UserEntity> users)
        {
            var user = users.FirstOrDefault(x => x.Password == model.Password && x.Login == model.Login);
            if (user == null || user.Role != UserRole.Admin)
                return null;

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Login!) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            return claimsIdentity;
        }
    }
}
