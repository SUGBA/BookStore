using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;

namespace BookStore.App.Services.Interfaces
{
    public interface IMainService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        Task<List<MainDto>> CreateViewModel();
    }
}
