using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;

namespace BookStore.EF.Repository.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<UserEntity>> GetUsers();

        /// <summary>
        /// Получить пользователя по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserEntity?> GetUserById(int id);

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task AddUser(UserEntity user);

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeleteUser(int id);

        /// <summary>
        /// Удаление пользователя по экзмепляру класса
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task DeleteUser(UserEntity user);

        /// <summary>
        /// Изменение пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task UpdateUser(UserEntity user);
    }
}
