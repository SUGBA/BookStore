using BookStore.App.Services.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepositrory _repository;

        public NewsService(INewsRepositrory repositrory)
        {
            _repository = repositrory;
        }

        public CatalogDto CreateViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
