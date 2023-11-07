using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.ContactDto;

namespace BookStore.App.Services.ContollerServices.Interfaces
{
    public interface ICatalogService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        Task<List<CatalogDto>> CreateViewModel();
    }
}
