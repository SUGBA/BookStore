using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.EntityDto.ContactDto
{
    public class ContactDto
    {
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
    }
}
