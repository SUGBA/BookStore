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
    public class DepartmentRepository : BaseRepository<DepartmentEntity>
    {
        public DepartmentRepository(BookStoreContext context) : base(context) { }

        protected override DbSet<DepartmentEntity> DbSet => _context.Departments;
    }
}
