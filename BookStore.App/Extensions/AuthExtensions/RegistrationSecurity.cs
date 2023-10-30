using System.Runtime.CompilerServices;
using System.Text;
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
        public static void AddSecurity(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddAuthorization();

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
                throw new ArgumentException();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = bool.Parse(validateIssuer),
                    ValidIssuer = validIssuer,
                    ValidateAudience = bool.Parse(validateAudience),
                    ValidAudience = validAudience,
                    ValidateLifetime = bool.Parse(validateLifetime),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateIssuerSigningKey = bool.Parse(validateIssuerSigningKey),
                };
            });

        }
    }
}
