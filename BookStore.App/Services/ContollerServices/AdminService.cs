using AutoMapper;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Admin.Dto;
using BookStore.Catalog.Dto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using BookStore.App.Services.AuthServices.Interfaces;

namespace BookStore.App.Services.ContollerServices
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AdminService(IUserRepository repositrory, IMapper mapper, IAuthService authService)
        {
            _repository = repositrory;
            _mapper = mapper;
            _authService = authService;
        }

        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public LoginUserDto CreateViewModel()
        {
            return new LoginUserDto();
        }

        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <returns></returns>
        public async Task<IResult> Login(LoginUserDto model)
        {
            var users = await _repository.GetUsers();
            IResult res = _authService.Auth(model, users);
            return res;
        }
    }
}
