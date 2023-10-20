﻿using System;
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
                        });
        }
    }
}
