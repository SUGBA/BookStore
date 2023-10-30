using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.Data.EntityDto.MainDto;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services.ContollerServices
{
    public class ContactService : IContactService
    {
        private readonly IManagerRepository _repository;
        private readonly IMapper _mapper;

        public ContactService(IManagerRepository repositrory, IMapper mapper)
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
            var list = await _repository.GetMangers();
            List<ContactDto> res = list.Select(x => _mapper.Map<ContactDto>(x)).ToList();
            return res;
        }
    }
}
