using AutoMapper;
using BookStore.App.Services.Interfaces;
using BookStore.Auth.Dto;
using BookStore.Catalog.Dto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookStore.App.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(IUserRepository repositrory, IMapper mapper)
        {
            _repository = repositrory;
            _mapper = mapper;
        }

        public LoginUserDto CreateViewModel()
        {
            return new LoginUserDto();
        }
    }
}
