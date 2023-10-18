using Microsoft.AspNetCore.Mvc;
using AspNetCore;
using BookStore.Auth.Entity;
using BookStore.EF.Repository.Interfaces;

namespace BookStore.App.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly IUserRepository _repository;

        public TestController(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        public async Task<List<UserEntity>> GetUsers()
        {
            return await _repository.GetUsers();
        }

        /// <summary>
        /// Получение списка пользователей
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddUsers")]
        public async Task<List<UserEntity>> AddUsers(UserEntity user)
        {
            await _repository.AddUser(user);
            return await _repository.GetUsers();
        }
        /// <summary>
        /// Удаление по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        public async Task<List<UserEntity>> DeleteUser(int id)
        {
            await _repository.DeleteUser(id);
            return await _repository.GetUsers();
        }

        /// <summary>
        /// Удаление по экземпляру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUser")]
        public async Task<List<UserEntity>> DeleteUser(UserEntity user)
        {
            await _repository.DeleteUser(user);
            return await _repository.GetUsers();
        }

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserById")]
        public async Task<UserEntity?> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }

        /// <summary>
        /// Изменить пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public async Task<List<UserEntity>> UpdateUser(UserEntity user)
        {
            await _repository.UpdateUser(user);
            return await _repository.GetUsers();
        }

    }
}
