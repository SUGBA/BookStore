using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services.ContollerServices
{
    public class NewsService : INewsService
    {
        private readonly IBaseRepository<NewsRepositrory> _repository;
        private readonly IMapper _mapper;

        public NewsService(IBaseRepository<NewsRepositrory> repositrory, IMapper mapper)
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
            var list = await _repository.GetAll().ToListAsync();
            List<NewsDto> res = list.Select(x => _mapper.Map<NewsDto>(x)).ToList();
            return res;
        }
    }
}
