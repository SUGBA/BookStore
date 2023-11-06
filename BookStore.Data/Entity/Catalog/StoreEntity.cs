using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Магазин
    /// </summary>
    public class StoreEntity : IEntity
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
        /// Филиал
        /// </summary>
        public int DepartmentEntityId { get; set; }

        /// <summary>
        /// Филиал
        /// </summary>
        public DepartmentEntity Department { get; set; } = new();

        /// <summary>
        /// Книга
        /// </summary>
        public int BookEntityId { get; set; }

        /// <summary>
        /// Книга
        /// </summary>
        public BookEntity Book { get; set; } = new();
    }
}
