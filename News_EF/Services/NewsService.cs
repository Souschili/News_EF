using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using News_EF.Data;
using News_EF.Models;

namespace News_EF.Services
{
    public class NewsService : INewsService
    {

        private NewsContext ndb;
       public NewsService(NewsContext context)
        {
            ndb = context;
        }
        /// <summary>
        /// Добавить новость в БД
        /// </summary>
        /// <param name="news"></param>
        public void AddNews(News news)
        {
            ndb.News.Add(news);
            ndb.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            throw new NotImplementedException();
        }
       /// <summary>
       /// Получить список всех новостей
       /// </summary>
       /// <returns></returns>
        public  async Task<List<News>> GetNewsAsync()
        {
             
            return await ndb.News.ToListAsync();
        }

        /// <summary>
        /// Получить новость для чтения по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public News ShowNews(int id)
        {
            var read_news = ndb.News.FirstOrDefault(x => x.Id == id);
            return read_news;
        }
    }
}
