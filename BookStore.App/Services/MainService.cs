using BookStore.App.Services.Interfaces;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class MainService : IMainService
    {
        private readonly IStoreRepository _repository;

        public MainService(IStoreRepository repositrory)
        {
            _repository = repositrory;
        }
    }
}
