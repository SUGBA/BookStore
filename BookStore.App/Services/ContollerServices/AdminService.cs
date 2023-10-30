using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Auth.Dto;
using BookStore.Catalog.Dto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AdminService(IUserRepository repositrory, IMapper mapper)
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
