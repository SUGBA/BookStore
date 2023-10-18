using AutoMapper;
using BookStore.App.Services.Interfaces;
using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class MainService : IMainService
    {
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;

        public MainService(IStoreRepository repositrory, IMapper mapper)
        {
            _repository = repositrory;
            _mapper = mapper;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public async Task<List<MainDto>> CreateViewModel()
        {
            var list = await _repository.GetStores();
            List<MainDto> res = list.Select(x => _mapper.Map<MainDto>(x)).ToList();
            return res;
        }
    }
}
