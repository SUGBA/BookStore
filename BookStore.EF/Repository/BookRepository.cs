using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class BookRepository : BaseRepository<BookEntity>
    {
        public BookRepository(BookStoreContext context) : base(context) { }

        protected override DbSet<BookEntity> DbSet => _context.Books;
    }
}
