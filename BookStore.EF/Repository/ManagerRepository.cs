using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly BookStoreContext _context;

        public ManagerRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить менеджера по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ManagerEntity?> GetManagerById(int id)
        {
            return await _context.Managers.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить список всех менеджеров
        /// </summary>
        /// <returns></returns>
        public async Task<List<ManagerEntity>> GetMangers()
        {
            return await _context.Managers.ToListAsync();
        }
    }
}
