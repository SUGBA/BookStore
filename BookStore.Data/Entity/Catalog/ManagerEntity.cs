using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Менеджеры магазинов
    /// </summary>
    public class ManagerEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя менеджера
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Почта менеджера
        /// </summary>
        public string? Mail { get; set; }

        /// <summary>
        /// Номер телефона менеджера
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Филиал
        /// </summary>
        public DepartmentEntity? Department { get; set; }
    }
}
