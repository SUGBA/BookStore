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
    public class Department
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public Manager? Manager { get; set; }

        /// <summary>
        /// Менеджер
        /// </summary>
        public int ManagerId { get; set; }

        /// <summary>
        /// Магазины
        /// </summary>
        public List<Store> Stores { get; set; } = new();
    }
}
