using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Admin.Entity;
using BookStore.EF.Context;
using BookStore.EF.Repository.Interfaces;
using BookStore.News.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.EF.Repository
{
    public class NewsRepositrory : IBaseRepository<NewsEntity>
    {
        private readonly BookStoreContext _context;

        public NewsRepositrory(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавить новость
        /// </summary>
        /// <returns></returns>
        public async Task AddNews(NewsEntity news)
        {
            if (news.Id == 0 || await GetNewsById(news.Id) == null)
            {
                await _context.News.AddAsync(news);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удалить новость по указанному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteNewsBuId(int id)
        {
            NewsEntity? deleteNews = await GetNewsById(id);
            if (deleteNews != null)
            {
                _context.News.Remove(deleteNews);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удалить новости
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task DeleteNews(NewsEntity news)
        {
            if (_context.News.Contains(news))
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получение списка новостей
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<NewsEntity>> GetNews()
        {
            return await _context.News.ToListAsync();
        }

        /// <summary>
        /// Получение новости по Id
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task<NewsEntity?> GetNewsById(int id)
        {
            return await _context.News.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Изменить новость
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public async Task UpdateNews(NewsEntity news)
        {
            if (_context.News.Any(x => x.Id == news.Id))
            {
                _context.News.Update(news);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<NewsEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<NewsEntity?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(NewsEntity item)
        {
            if (item.Id == 0 || await GetNewsById(item.Id) == null)
            {
                await _context.News.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteBuId(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(NewsEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
