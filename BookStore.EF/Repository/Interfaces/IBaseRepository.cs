﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        Task DeleteBuId(int id);

        /// <summary>
        /// Получение элемента по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetById(int id);

        /// <summary>
        /// Изменить элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task Update(T item);
    }
}
