using BookStore.Admin.Dto;
using BookStore.Data.EntityDto.MainDto;

namespace BookStore.App.Services.ContollerServices.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public LoginUserDto CreateViewModel(string Login = "", string Password = "", string Message = "");

        /// <summary>
        /// Авторизоваться. True - удалось авторизоваться, False - не удалось авторизоваться
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<bool> Login(LoginUserDto model, HttpContext context);
    }
}
