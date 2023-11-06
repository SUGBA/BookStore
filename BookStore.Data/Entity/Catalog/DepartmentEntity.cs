using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Филиал
    /// </summary>
    public class DepartmentEntity : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public ManagerEntity? Manager { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public int ManagerEntityId { get; set; }

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
