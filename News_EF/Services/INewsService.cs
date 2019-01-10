using News_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Services
{
    public interface INewsService
    {

        //реализует CRUD операции,неважно какая БД
        Task<IEnumerable<News>> GetNewsAsync();
        void AddNews(News news);
        News ShowNews();
        void DeleteNews(int id);
    }
}
