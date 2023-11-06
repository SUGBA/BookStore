using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.Data.EntityDto.MainDto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Services.ContollerServices
{
    public class ContactService : IContactService
    {
        private readonly IBaseRepository<ManagerEntity> _repository;
        private readonly IMapper _mapper;

        public ContactService(IBaseRepository<ManagerEntity> repositrory, IMapper mapper)
        {
            _repository = repositrory;
            _mapper = mapper;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContactDto>> CreateViewModel()
        {
            var list = await _repository.GetAll().ToListAsync();
            List<ContactDto> res = list.Select(x => _mapper.Map<ContactDto>(x)).ToList();
            return res;
        }
    }
}
