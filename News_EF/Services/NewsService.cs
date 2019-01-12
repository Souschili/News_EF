﻿using System;
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

        public void AddNews(News news)
        {
            ndb.Add(news);
            ndb.SaveChanges();
        }

        public void DeleteNews(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<List<News>> GetNewsAsync()
        {
             
            return await ndb.News.ToListAsync();
        }

        public News ShowNews()
        {
            throw new NotImplementedException();
        }
    }
}
