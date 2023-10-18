using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.EntityDto.NewsDto
{
    public class NewsDto
    {
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
