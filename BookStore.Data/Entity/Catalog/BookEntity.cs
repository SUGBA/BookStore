using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookEntity : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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
        public int Price { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public string Genre { get; set; } = null!;

        /// <summary>
        /// Магазины
        /// </summary>
        public List<StoreEntity> Stores { get; set; } = new();

        /// <summary>
        /// Филиалы
        /// </summary>
        public List<DepartmentEntity> Departments { get; set; } = new();
    }
}
