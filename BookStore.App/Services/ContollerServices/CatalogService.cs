﻿using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Dto;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.CatalogDto;
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

        /// <summary>
        /// Собрать ViewModel по настрйкам сортировки
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatalogDto>> CreateViewModel(SortPropertyDto model)
        {
            var list = await _repository.GetAll()
                .Include(x => x.Book)
                .Include(y => y.Department)
                .ThenInclude(y => y.Manager)
                .ToListAsync();

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
