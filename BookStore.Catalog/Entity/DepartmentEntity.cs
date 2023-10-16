using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Филиал
    /// </summary>
    public class DepartmentEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public ManagerEntity? Manager { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Магазины
        /// </summary>
        public List<StoreEntity> Stores { get; set; } = new();

        /// <summary>
        /// Книги
        /// </summary>
        public List<BookEntity> Books { get; set; } = new();
    }
}
