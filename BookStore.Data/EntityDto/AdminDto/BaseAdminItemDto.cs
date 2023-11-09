using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookStore.Data.EntityDto.AdminDto
{
    public class BaseAdminItemDto
    {
        /// <summary>
        /// Идентификатор элемента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Отображаемое имя (название книги/содержимое новости/имя пользователя)
        /// </summary>
        public string ViewName { get; set; } = string.Empty;
    }
}
