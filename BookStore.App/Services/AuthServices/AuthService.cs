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

namespace BookStore.App.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"> DTO из вьюхи</param>
        /// <param name="users"> Список пользователей </param>
        /// <returns></returns>
        public IResult Auth(LoginUserDto model, List<UserEntity> users)
        {
            var user = users.FirstOrDefault(x => x.Password == model.Password && x.Login == model.Login);
            if (user == null || user.Role != UserRole.Admin)
                return Results.Unauthorized();

            var jwtOptions = GetAuthOptions();
            if (jwtOptions == null)
                return Results.Problem();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Login!) };

            var token = new JwtSecurityToken(
                issuer: jwtOptions.ValidIssuer,
                audience: jwtOptions.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(jwtOptions.IssuerSigningKey, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = model.Login
            };

            return Results.Json(response);
        }

        /// <summary>
        /// Получение настроек аутентификационных настроек из конфигурации
        /// </summary>
        /// <returns></returns>
        private TokenValidationParameters? GetAuthOptions()
        {
            var key = _configuration["AuthenticationOptions:KEY"];
            var validateIssuer = _configuration["AuthenticationOptions:ValidateIssuer"];
            var validIssuer = _configuration["AuthenticationOptions:ValidIssuer"];
            var validateAudience = _configuration["AuthenticationOptions:ValidateAudience"];
            var validAudience = _configuration["AuthenticationOptions:ValidAudience"];
            var validateLifetime = _configuration["AuthenticationOptions:ValidateLifetime"];
            var validateIssuerSigningKey = _configuration["AuthenticationOptions:ValidateIssuerSigningKey"];

            if (string.IsNullOrEmpty(validateIssuer) || string.IsNullOrEmpty(validIssuer) ||
                string.IsNullOrEmpty(validateAudience) || string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(validAudience) || string.IsNullOrEmpty(validateLifetime) || string.IsNullOrEmpty(validateIssuerSigningKey))
                return null;

            var res = new TokenValidationParameters()
            {
                ValidateIssuer = bool.Parse(validateIssuer),
                ValidIssuer = validIssuer,
                ValidateAudience = bool.Parse(validateAudience),
                ValidAudience = validAudience,
                ValidateLifetime = bool.Parse(validateLifetime),
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateIssuerSigningKey = bool.Parse(validateIssuerSigningKey),
            };

            return res;
        }
    }
}
