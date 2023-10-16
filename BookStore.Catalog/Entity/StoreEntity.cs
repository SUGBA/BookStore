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
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Количество книг
        /// </summary>
        public int BookCount { get; set; }

        /// <summary>
        /// Филиалы
        /// </summary>
        public List<DepartmentEntity> Departments { get; set; } = new();

        /// <summary>
        /// Книги
        /// </summary>
        public List<BookEntity> Books { get; set; } = new();
    }
}
