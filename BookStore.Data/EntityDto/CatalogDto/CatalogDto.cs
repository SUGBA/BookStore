using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Catalog.Entity;

namespace BookStore.Catalog.Dto
{
    public class CatalogDto
    {
        /// <summary>
        /// Название книги
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Путь до картинки
        /// </summary>
        public string? PathToImage { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public Genres Genre { get; set; }

        /// <summary>
        /// Филиалы
        /// </summary>
        public List<string> DepartmentsAddress { get; set; } = new();

        /// <summary>
        /// Количество книг
        /// </summary>
        public int BookCount { get; set; }
    }
}
