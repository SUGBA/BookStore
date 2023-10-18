using BookStore.App.Services.Interfaces;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IStoreRepository _repository;

        public CatalogService(IStoreRepository repositrory)
        {
            _repository = repositrory;
        }
    }
}
