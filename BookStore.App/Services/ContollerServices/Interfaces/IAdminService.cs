using BookStore.Auth.Dto;
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
    }
}
