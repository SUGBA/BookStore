using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services.ContollerServices
{
    public class MainService : IMainService
    {
        /// <summary>
        /// Количество элементов в нижней панели
        /// </summary>
        private const int LOWER_PANEL_ITEMS = 6;

        private readonly IBaseRepository<BookEntity> _repository;

        private readonly IMapper _mapper;

        public MainService(IBaseRepository<BookEntity> repositrory, IMapper mapper)
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
            var list = await _repository.GetAll().ToListAsync();
            List<MainDto> res = list.Take(LOWER_PANEL_ITEMS).Select(x => _mapper.Map<MainDto>(x)).ToList();
            return res;
        }
    }
}
