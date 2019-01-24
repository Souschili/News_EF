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

        public async Task<bool> AddComentAsync (int NewsId, string auth,string text)
        {
            var news = ndb.News.Where(x => x.Id == NewsId).Include(e => e.Coments).FirstOrDefault();
            if(news!=null)
            {
                //если мы вытащили новость то пилим комент и добавляем
                var com = new Comments
                {
                    Author = auth,
                    Text = text
                };
                news.Coments.Add(com);
               await ndb.SaveChangesAsync();
               //цведомляем что запись прошла и новость существует
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить новость в БД
        /// </summary>
        /// <param name="news"></param>
        public async Task AddNewsAsync(News news)
        {
           await ndb.AddAsync(news);
           ndb.SaveChanges();
        }
        /// <summary>
        /// Удалить коментарий в новости
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newsid"></param>
        /// <returns></returns>
        public async Task<bool> DeleteComentAsync(int id)
        {
            //вытягиваем новость с коментами
            var coment =await ndb.Coments.FirstOrDefaultAsync(x => x.Id == id);
            if(coment!=null)
            {
                ndb.Coments.Remove(coment);
                await ndb.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Удаляем новость по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteNewsAsync(int id)
        {
            //вытягиваем новость+коменты
            var delnews = await ndb.News.Where(x => x.Id == id).Include(x => x.Coments).FirstOrDefaultAsync();
            //удаляем новость каскадное удаление включенно по умолчанию так что просто удаляем 
            if (delnews != null)
            {
                ndb.News.Remove(delnews);
                await ndb.SaveChangesAsync();
                return true;
            }
            return false;
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
        public async Task<News> ShowNewsAsync(int id)
        {
            var read_news = await ndb.News.Where(x => x.Id == id)
                           .Include(e => e.Coments).FirstOrDefaultAsync();
            return read_news;
        }

    }
}
