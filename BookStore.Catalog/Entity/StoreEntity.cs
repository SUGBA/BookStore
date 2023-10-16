using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Магазин
    /// </summary>
    public class StoreEntity
    {
        /// <summary>
        /// Количество книг
        /// </summary>
        public int BookCount { get; set; }


        /// <summary>
        /// Филиал
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Филиал
        /// </summary>
        public DepartmentEntity Department { get; set; } = new();

        /// <summary>
        /// Книга
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Книга
        /// </summary>
        public DepartmentEntity Book { get; set; } = new();
    }
}
