using BookStore.App.Services.Interfaces;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookStore.App.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;

        public LoginService(IUserRepository repositrory)
        {
            _repository = repositrory;
        }
    }
}
