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
        LoginUserDto CreateViewModel();

        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <returns></returns>
        public Task<IResult> Login(LoginUserDto model);
    }
}
