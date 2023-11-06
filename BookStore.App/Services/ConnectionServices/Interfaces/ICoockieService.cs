using System.Security.Claims;
using BookStore.Admin.Dto;
using BookStore.Admin.Entity;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.App.Services.AuthServices.Interfaces
{
    public interface ICoockieService
    {
        /// <summary>
        /// Авторизация пользователя. Null - не удалось авторизоваться
        /// </summary>
        /// <param name="model"> DTO из вьюхи</param>
        /// <param name="users"> Список пользователей </param>
        /// <returns></returns>
        public ClaimsIdentity? GetClaimsIdentity(LoginUserDto model, List<UserEntity> users);
    }
}
