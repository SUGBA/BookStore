using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.NewsDto;

namespace BookStore.App.Services.ContollerServices.Interfaces
{
    public interface INewsService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        Task<List<NewsDto>> CreateViewModel();
    }
}
