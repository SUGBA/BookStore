using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task Delete(TEntity item)
        {
            DbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получение списка элементов
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        /// <summary>
        /// Получение элементов по выборке
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
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
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получение новости по Id с дозагрузкой
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetById(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = IncludeItems(includeProperties);
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Отслеживание переданной сущности
        /// </summary>
        /// <param name="item"></param>
        public void Attach(TEntity item)
        {
            if (DbSet.Any(x => x == item))
                _context.Attach(item);
        }

        /// <summary>
        /// Получение элементов с дозагрузкой 
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return IncludeItems(includeProperties).ToList();
        }

        /// <summary>
        /// Получение элементов с дозагрузкой
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = IncludeItems(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> IncludeItems(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
