using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly BookStoreContext _context;

        public StoreRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление магазина
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task AddStore(StoreEntity store)
        {
            if ((store.DepartmentEntityId == 0 && store.BookEntityId == 0) || await GetStoreById(store.DepartmentEntityId, store.BookEntityId) == null)
            {
                await _context.Stores.AddAsync(store);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаление магазина по экзмепляру класса
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task DeleteStore(StoreEntity store)
        {
            if (_context.Stores.Contains(store))
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаление магазина по Id магазина и Id книги
        /// </summary>
        /// <param name="idStore"></param>
        /// <param name="idBook"></param>
        /// <returns></returns>
        public async Task DeleteStoreBuId(int idDepartment, int idBook)
        {
            StoreEntity? deletedStore = await GetStoreById(idDepartment, idBook);
            if (deletedStore != null)
            {
                _context.Stores.Remove(deletedStore);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить магазин по Id магазина и Id книги
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StoreEntity?> GetStoreById(int idDepartment, int idBook)
        {
            return await _context.Stores
                        .Include(x => x.Book)
                        .Include(y => y.Department)
                        .ThenInclude(k => k.Manager)
                        .FirstOrDefaultAsync(x => x.DepartmentEntityId == idDepartment && x.BookEntityId == idBook);
        }

        /// <summary>
        /// Получить список всех магазинов
        /// </summary>
        /// <returns></returns>
        public async Task<List<StoreEntity>> GetStores()
        {
            return await _context.Stores
                        .Include(x => x.Book)
                        .Include(y => y.Department)
                        .ThenInclude(k => k.Manager)
                        .ToListAsync();
        }

        /// <summary>
        /// Изменить магазин
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task UpdateStore(StoreEntity store)
        {
            if (_context.Stores.Any(x => x.DepartmentEntityId == store.DepartmentEntityId && x.BookEntityId == store.BookEntityId))
            {
                _context.Stores.Update(store);
                await _context.SaveChangesAsync();
            }
        }
    }
}
