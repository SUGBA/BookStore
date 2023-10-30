using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Admin.Dto
{
    public class LoginUserDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }
    }
}
