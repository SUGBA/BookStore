using System.Runtime.CompilerServices;
using System.Text;
using BookStore.App.Data.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.App.Extensions.AuthExtensions
{
    public static class RegistrationSecurity
    {
        public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();

            var key = configuration["AuthenticationOptions:KEY"];
            var validateIssuer = configuration["AuthenticationOptions:ValidateIssuer"];
            var validIssuer = configuration["AuthenticationOptions:ISSUER"];
            var validateAudience = configuration["AuthenticationOptions:ValidateAudience"];
            var validAudience = configuration["AuthenticationOptions:AUDIENCE"];
            var validateLifetime = configuration["AuthenticationOptions:ValidateLifetime"];
            var validateIssuerSigningKey = configuration["AuthenticationOptions:ValidateIssuerSigningKey"];

            if (string.IsNullOrEmpty(validateIssuer) || string.IsNullOrEmpty(validIssuer) ||
                string.IsNullOrEmpty(validateAudience) || string.IsNullOrEmpty(key) ||
                string.IsNullOrEmpty(validAudience) || string.IsNullOrEmpty(validateLifetime) || string.IsNullOrEmpty(validateIssuerSigningKey))
                throw new ArgumentException();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // указывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = bool.Parse(validateIssuer),
                    // строка, представляющая издателя
                    ValidIssuer = validIssuer,
                    // будет ли валидироваться потребитель токена
                    ValidateAudience = bool.Parse(validateAudience),
                    // установка потребителя токена
                    ValidAudience = validAudience,
                    // будет ли валидироваться время существования
                    ValidateLifetime = bool.Parse(validateLifetime),
                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = bool.Parse(validateIssuerSigningKey),
                };
            });

        }
    }
}
