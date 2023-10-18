using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;

namespace BookStore.Data.EntityDto.CatalogDto
{
    public class SortPropertyDto
    {
        /// <summary>
        /// Выбранный жанр
        /// </summary>
        public Genres? Genre { get; set; }

        /// <summary>
        /// Выбранный адресс
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Максимальная цеа
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Максимум страниц
        /// </summary>
        public int PageCount { get; set; }
    }
}
