using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Auth.Entity
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string? Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Роль пользователя
        /// </summary>
        public UserRole Role { get; set; }
    }

    /// <summary>
    /// Роли пользователей
    /// </summary>
    public enum UserRole : byte
    {
        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 1,

        /// <summary>
        /// пользлватель
        /// </summary>
        User = 2
    }
}
