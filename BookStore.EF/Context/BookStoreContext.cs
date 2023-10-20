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

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
                    .HasMany(e => e.Departments)
                    .WithMany(e => e.Books)
                    .UsingEntity<StoreEntity>(
                        l => l.HasOne(e => e.Department).WithMany(e => e.Stores).HasForeignKey(e => e.DepartmentEntityId),
                        k => k.HasOne(e => e.Book).WithMany(e => e.Stores).HasForeignKey(e => e.BookEntityId),
                        m =>
                        {
                            m.HasKey(e => new { e.DepartmentEntityId, e.BookEntityId });
                            m.ToTable("Stores");
                            m.HasData(
                               new { BookCount = 50, BookEntityId = 1, DepartmentEntityId = 1 },
                               new { BookCount = 30, BookEntityId = 2, DepartmentEntityId = 2 },
                               new { BookCount = 27, BookEntityId = 3, DepartmentEntityId = 3 },
                               new { BookCount = 18, BookEntityId = 4, DepartmentEntityId = 1 },
                               new { BookCount = 99, BookEntityId = 5, DepartmentEntityId = 2 },
                               new { BookCount = 56, BookEntityId = 6, DepartmentEntityId = 3 },
                               new { BookCount = 57, BookEntityId = 7, DepartmentEntityId = 1 },
                               new { BookCount = 58, BookEntityId = 8, DepartmentEntityId = 2 },
                               new { BookCount = 12, BookEntityId = 9, DepartmentEntityId = 3 },
                               new { BookCount = 14, BookEntityId = 10, DepartmentEntityId = 1 },
                               new { BookCount = 15, BookEntityId = 11, DepartmentEntityId = 2 },
                               new { BookCount = 3, BookEntityId = 12, DepartmentEntityId = 3 }
                            );
                        });
        }
    }
}
