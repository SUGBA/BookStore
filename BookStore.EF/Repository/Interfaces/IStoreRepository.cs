using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    interface IStoreRepository
    {
        /// <summary>
        /// Добавление магазина
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Task AddStore(StoreEntity store);

        /// <summary>
        /// Получить список всех магазинов
        /// </summary>
        /// <returns></returns>
        Task<List<StoreEntity>> GetStores();

        /// <summary>
        /// Получение мгазина по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StoreEntity?> GetStoreById(int id);

        /// <summary>
        /// Изменение магазина
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task UpdateStore(StoreEntity store);

        /// <summary>
        /// Удаление пользователя по экземпляру
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        Task DeleteStore(StoreEntity store);

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteStore(int id);
    }
}
