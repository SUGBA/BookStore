using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;
using BookStore.News.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IStoreRepository
    {
        /// <summary>
        /// Получить список всех магазинов
        /// </summary>
        /// <returns></returns>
        Task<List<StoreEntity>> GetStores();

        /// <summary>
        /// Получить магазин по Id магазина и Id книги
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StoreEntity?> GetStoreById(int idDepartment, int idBook);

        /// <summary>
        /// Добавление магазина
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task AddStore(StoreEntity store);

        /// <summary>
        /// Удаление магазина по Id магазина и Id книги
        /// </summary>
        /// <param name="idDepartment"></param>
        /// <param name="idBook"></param>
        /// <returns></returns>
        Task DeleteStoreBuId(int idDepartment, int idBook);

        /// <summary>
        /// Удаление магазина по экзмепляру класса
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task DeleteStore(StoreEntity store);

        /// <summary>
        /// Изменить магазин
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        Task UpdateStore(StoreEntity store);
    }
}
