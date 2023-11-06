using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly BookStoreContext _context;

        protected abstract DbSet<TEntity> DbSet { get; }

        public BaseRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <returns></returns>
        public async Task Add(TEntity item)
        {
            if (item.Id == 0 || await GetById(item.Id) == null)
            {
                await DbSet.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удалить элемент
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task DeleteBuId(int id)
        {
            TEntity? item = await GetById(id);
            if (item != null)
            {
                DbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получение списка элементов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Изменить элемент
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Update(TEntity item)
        {
            if (DbSet.Any(x => x.Id == item.Id))
            {
                DbSet.Update(item);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получение новости по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetById(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
