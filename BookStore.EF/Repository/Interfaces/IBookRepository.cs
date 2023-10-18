using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Получить список всех книг
        /// </summary>
        /// <returns></returns>
        Task<List<BookEntity>> GetBooks();

        /// <summary>
        /// Получить книгу по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<BookEntity?> GetBookById(int id);
    }
}
