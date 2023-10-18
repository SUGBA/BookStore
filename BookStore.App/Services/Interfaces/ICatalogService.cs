using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.CatalogDto;
using BookStore.Data.EntityDto.ContactDto;

namespace BookStore.App.Services.Interfaces
{
    public interface ICatalogService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        Task<List<CatalogDto>> CreateViewModel();

        /// <summary>
        /// Собрать ViewModel по настрйкам сортировки
        /// </summary>
        /// <returns></returns>
        Task<List<CatalogDto>> CreateViewModel(SortPropertyDto model);
    }
}
