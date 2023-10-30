using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.Data.EntityDto.CatalogDto;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services.ContollerServices
{
    public class CatalogService : ICatalogService
    {
        private readonly IStoreRepository _repository;
        private readonly IMapper _mapper;

        public CatalogService(IStoreRepository repositrory, IMapper mapper)
        {
            _repository = repositrory;
            _mapper = mapper;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatalogDto>> CreateViewModel()
        {
            var list = await _repository.GetStores();
            List<CatalogDto> res = list.Select(x => _mapper.Map<CatalogDto>(x)).ToList();
            return res;
        }

        /// <summary>
        /// Собрать ViewModel по настрйкам сортировки
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatalogDto>> CreateViewModel(SortPropertyDto model)
        {
            var list = await _repository.GetStores();
            IEnumerable<CatalogDto> res = list.Select(x => _mapper.Map<CatalogDto>(x)).ToList();
            if (model.PageCount > 0)
                res = res.Where(x => x.PageCount <= model.PageCount);
            if (model.Price > 0)
                res = res.Where(x => x.Price <= model.Price);
            if (model.Address != null)
                res = res.Where(x => x.DepartmentsAddress.Any(y => y == model.Address));
            if (model.Genre != null)
                res = res.Where(x => x.Genre == model.Genre);

            return res.ToList();
        }
    }
}
