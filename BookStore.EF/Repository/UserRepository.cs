using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Auth.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext _context;

        public UserRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddUser(UserEntity user)
        {
            if (user.Id == 0 || await GetUserById(user.Id) == null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUser(int id)
        {
            UserEntity? deletedUser = await GetUserById(id);
            if (deletedUser != null)
            {
                _context.Users.Remove(deletedUser);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удаление пользователя по экзмепляру класса
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DeleteUser(UserEntity user)
        {
            if (_context.Users.Contains(user))
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получить пользователя по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserEntity?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntity>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Изменение пользователя по экзмепляру класса
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task UpdateUser(UserEntity user)
        {
            if (_context.Users.Any(x => x.Id == user.Id))
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
