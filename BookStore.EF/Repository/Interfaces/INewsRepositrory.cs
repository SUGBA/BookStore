using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.News.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface INewsRepositrory
    {
        /// <summary>
        /// Получить список всех новостей
        /// </summary>
        /// <returns></returns>
        Task<List<NewsEntity>> GetNews();

        /// <summary>
        /// Получить новость по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NewsEntity?> GetNewsById(int id);

        /// <summary>
        /// Добавление новости
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task AddNews(NewsEntity news);

        /// <summary>
        /// Удаление новости по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteNewsBuId(int id);

        /// <summary>
        /// Удаление новости по экзмепляру класса
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task DeleteNews(NewsEntity news);

        /// <summary>
        /// Изменить новость
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task UpdateNews(NewsEntity news);
    }
}
