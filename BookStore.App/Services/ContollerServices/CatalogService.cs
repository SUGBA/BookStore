using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services.ContollerServices
{
    public class CatalogService : ICatalogService
    {
        private readonly IBaseRepository<StoreEntity> _repository;
        private readonly IMapper _mapper;

        public CatalogService(IBaseRepository<StoreEntity> repositrory, IMapper mapper)
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
            var list = await _repository.GetAll()
                .Include(x => x.Book)
                .Include(y => y.Department)
                .ThenInclude(y => y.Manager)
                .ToListAsync();

            List<CatalogDto> res = list.Select(x => _mapper.Map<CatalogDto>(x)).ToList();
            return res;
        }
    }
}
