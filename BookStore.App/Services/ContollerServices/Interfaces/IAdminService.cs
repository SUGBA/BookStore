using BookStore.Admin.Dto;
using BookStore.Admin.Entity;
using BookStore.Catalog.Dto;
using BookStore.Catalog.Entity;
using BookStore.Data.EntityDto.AdminDto;
using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.News.Entity;

namespace BookStore.App.Services.ContollerServices.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// Собрать ViewModel
        /// </summary>
        /// <returns></returns>
        public LoginUserDto CreateViewModel(string Login = "", string Password = "", string Message = "");

        /// <summary>
        /// Авторизоваться. True - удалось авторизоваться, False - не удалось авторизоваться
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task<bool> Login(LoginUserDto model, HttpContext context);

        /// <summary>
        /// Получить ViewModel без выбранного пользователя
        /// </summary>
        /// <returns></returns>
        public Task<AdminItemsDto<UserEntity>> UserViewModel();

        /// <summary>
        /// Получить ViewModel без выбранной книги
        /// </summary>
        /// <returns></returns>
        public Task<AdminItemsDto<StoreEntity>> CatalogViewModel();

        /// <summary>
        /// Получить ViewModel без выбранной новости
        /// </summary>
        /// <returns></returns>
        public Task<AdminItemsDto<NewsEntity>> NewsViewModel();

        /// <summary>
        /// Получить ViewModel с выбранным пользователем
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<AdminItemsDto<UserEntity>> UserViewModel(int itemId);

        /// <summary>
        /// Получить ViewModel с выбранной книгой
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<AdminItemsDto<StoreEntity>> CatalogViewModel(int departmentId, int bookId);

        /// <summary>
        /// Получить ViewModel с выбранной новостью
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<AdminItemsDto<NewsEntity>> NewsViewModel(int itemId);
    }
}
