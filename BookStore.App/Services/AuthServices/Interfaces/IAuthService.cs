using BookStore.Admin.Dto;
using BookStore.Admin.Entity;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.App.Services.AuthServices.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model"> DTO из вьюхи</param>
        /// <param name="users"> Список пользователей </param>
        /// <returns></returns>
        public IResult Auth(LoginUserDto model, List<UserEntity> users);
    }
}
