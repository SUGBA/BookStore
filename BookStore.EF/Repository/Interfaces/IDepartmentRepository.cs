using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// Получить список всех отделений
        /// </summary>
        /// <returns></returns>
        Task<List<DepartmentEntity>> GetDepartments();

        /// <summary>
        /// Получить отделение по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DepartmentEntity?> GetDepartmentById(int id);
    }
}
