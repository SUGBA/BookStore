using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;
using BookStore.News.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Получить список всех элементов
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Добавление элемента
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Add(T item);

        /// <summary>
        /// Удаление элемента по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(T item);

        /// <summary>
        /// Получение элемента по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetById(int id);

        /// <summary>
        /// Отслеживание переданной сущности
        /// </summary>
        /// <param name="item"></param>
        public void Attach(T item);

        /// <summary>
        /// Получение новости по Id с дозагрузкой
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public Task<T?> GetById(int id, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Изменить элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Update(T item);

        /// <summary>
        /// Получение элементов с дозагрузкой 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Получение элементов с дозагрузкой
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

    }
}
