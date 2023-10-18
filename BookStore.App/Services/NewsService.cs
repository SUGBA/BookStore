using AutoMapper;
using BookStore.App.Services.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepositrory _repository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepositrory repositrory, IMapper mapper)
        {
            _repository = repositrory;
            _mapper = mapper;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsDto>> CreateViewModel()
        {
            var list = await _repository.GetNews();
            List<NewsDto> res = list.Select(x => _mapper.Map<NewsDto>(x)).ToList();
            return res;
        }
    }
}
