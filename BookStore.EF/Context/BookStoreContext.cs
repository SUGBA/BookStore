using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Context
{
    public class BookStoreContext : DbContext
    {
        public DbSet<NewsEntity> News { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<ManagerEntity> Managers { get; set; }

        public DbSet<DepartmentEntity> Departments { get; set; }

        public DbSet<StoreEntity> Stores { get; set; }
    }
}
