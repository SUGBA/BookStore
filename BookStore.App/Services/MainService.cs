using AutoMapper;
using BookStore.App.Services.Interfaces;
using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class MainService : IMainService
    {
        /// <summary>
        /// Количество элементов в нижней панели
        /// </summary>
        private const int LOWER_PANEL_ITEMS = 6;

        private readonly IBookRepository _repository;

        private readonly IMapper _mapper;

        public MainService(IBookRepository repositrory, IMapper mapper)
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
            var list = await _repository.GetBooks();
            List<MainDto> res = list.Take(LOWER_PANEL_ITEMS).Select(x => _mapper.Map<MainDto>(x)).ToList();
            return res;
        }
    }
}
