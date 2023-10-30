using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить книгу по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookEntity?> GetBookById(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить список всех книг
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookEntity>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
