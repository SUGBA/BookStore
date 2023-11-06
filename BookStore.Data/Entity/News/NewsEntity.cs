using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Data.Entity;

namespace BookStore.News.Entity
{
    /// <summary>
    /// Новость
    /// </summary>
    public class NewsEntity : IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Путь до картинки
        /// </summary>
        public string? PathToImage { get; set; }

        /// <summary>
        /// Содержимое новости
        /// </summary>
        public string? Content { get; set; }
    }
}
