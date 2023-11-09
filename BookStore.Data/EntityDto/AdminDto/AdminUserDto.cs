using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;

namespace BookStore.Data.EntityDto.AdminDto
{
    public class AdminUserDto : BaseAdminItemDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public UserRole Role { get; set; }
    }
}
