using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Catalog.Entity
{
    /// <summary>
    /// Книга
    /// </summary>
    public class BookEntity
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
        /// Магазины
        /// </summary>
        public List<StoreEntity> Stores { get; set; } = new();

        /// <summary>
        /// Филиалы
        /// </summary>
        public List<DepartmentEntity> Departments { get; set; } = new();
    }

    /// <summary>
    /// Жанры книг
    /// </summary>
    public enum Genres : byte
    {
        /// <summary>
        /// Фантастика
        /// </summary>
        Fantasy = 1,

        /// <summary>
        /// Проза
        /// </summary>
        Prose = 2,

        /// <summary>
        /// Научно-популярная
        /// </summary>
        PopularScience = 3,

        /// <summary>
        /// Зарубежная
        /// </summary>
        Foreign = 4,

        /// <summary>
        /// Отечественная
        /// </summary>
        Domestic = 5
    }
}
