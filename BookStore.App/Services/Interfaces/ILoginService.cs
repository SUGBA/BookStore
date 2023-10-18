using BookStore.Auth.Dto;
using BookStore.Data.EntityDto.MainDto;

namespace BookStore.App.Services.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        LoginUserDto CreateViewModel();
    }
}
