using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class ManagerRepository : BaseRepository<ManagerEntity>
    {
        public ManagerRepository(BookStoreContext context) : base(context) { }

        protected override DbSet<ManagerEntity> DbSet => _context.Managers;
    }
}
