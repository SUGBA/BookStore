using System.Runtime.CompilerServices;
using BookStore.Auth.Entity;
using BookStore.EF.Repository.Interfaces;
using BookStore.News.Entity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly INewsRepositrory _newsRepository;

        public TestController(IUserRepository repository, INewsRepositrory newsRepository)
        {
            _repository = repository;
            _newsRepository = newsRepository;
        }

        #region

        #endregion

        #region NewsRepository

        /// <summary>
        /// Получить список всех новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNews")]
        public async Task<List<NewsEntity>> GetNews()
        {
            return await _newsRepository.GetNews();
        }

        /// <summary>
        /// Получить новость по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetNewsById")]
        public Task<NewsEntity?> GetNewsById(int id)
        {
            return _newsRepository.GetNewsById(id);
        }

        /// <summary>
        /// Добавление новости
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPost("AddNews")]
        public async Task<List<NewsEntity>> AddNews(NewsEntity news)
        {
            await _newsRepository.AddNews(news);
            return await _newsRepository.GetNews();
        }

        /// <summary>
        /// Удаление новости по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteNewsBuId")]
        public async Task<List<NewsEntity>> DeleteNewsBuId(int id)
        {
            await _newsRepository.DeleteNewsBuId(id);
            return await _newsRepository.GetNews();
        }

        /// <summary>
        /// Удаление новости по экзмепляру класса
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpDelete("DeleteNews")]
        public async Task<List<NewsEntity>> DeleteNews(NewsEntity news)
        {
            await _newsRepository.DeleteNews(news);
            return await _newsRepository.GetNews();
        }

        /// <summary>
        /// Изменить новость
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [HttpPut("UpdateNews")]
        public async Task<List<NewsEntity>> UpdateNews(NewsEntity news)
        {
            await _newsRepository.UpdateNews(news);
            return await _newsRepository.GetNews();
        }

        #endregion

        #region UserRepository
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
        [HttpDelete("DeleteUserById")]
        public async Task<List<UserEntity>> DeleteUserById(int id)
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

        #endregion
    }
}
