using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;
using BookStore.EF.Context;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class NewsRepositrory : BaseRepository<NewsEntity>
    {
        public NewsRepositrory(BookStoreContext context) : base(context) { }

        protected override DbSet<NewsEntity> DbSet => _context.News;
    }
}
