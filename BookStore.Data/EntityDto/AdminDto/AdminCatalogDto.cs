using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.EntityDto.AdminDto
{
    public class AdminCatalogDto : BaseAdminItemDto
    {
        /// <summary>
        /// Цена
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Адрес магазина
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Количество книг
        /// </summary>
        public string BookCount { get; set; } = string.Empty;
    }
}
