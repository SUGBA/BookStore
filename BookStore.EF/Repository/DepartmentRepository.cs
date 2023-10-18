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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly BookStoreContext _context;

        public DepartmentRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить отделение по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DepartmentEntity?> GetDepartmentById(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить список всех отделений
        /// </summary>
        /// <returns></returns>
        public async Task<List<DepartmentEntity>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
