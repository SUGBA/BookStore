using BookStore.App.Services.Interfaces;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Services
{
    public class ContactService : IContactService
    {
        private readonly IDepartmentRepository _repository;

        public ContactService(IDepartmentRepository repositrory)
        {
            _repository = repositrory;
        }
    }
}
