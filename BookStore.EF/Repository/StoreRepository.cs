using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;

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
        /// <param name="store"></param>
        /// <returns></returns>
        public async Task AddStore(StoreEntity store)
        {
            await _context.Stores.AddAsync(store);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получить список всех магазинов
        /// </summary>
        /// <returns></returns>
        public Task DeleteStore(StoreEntity store)
        {
            //И чо с тобой делать, клю то у тебя составной
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение мгазина по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteStore(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Изменение магазина
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Task<StoreEntity?> GetStoreById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление пользователя по экземпляру
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Task<List<StoreEntity>> GetStores()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task UpdateStore(StoreEntity store)
        {
            throw new NotImplementedException();
        }
    }
}
