using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IManagerRepository
    {
        /// <summary>
        /// Получить список всех менеджеров
        /// </summary>
        /// <returns></returns>
        Task<List<ManagerEntity>> GetMangers();

        /// <summary>
        /// Получить менеджера по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ManagerEntity?> GetManagerById(int id);
    }
}
