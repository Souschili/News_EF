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
        Task<List<News>> GetNewsAsync();
        Task AddNewsAsync(News news);
        Task<News> ShowNewsAsync(int id);
        Task<bool> AddComent(int NewsId, string auth,string text);
        Task DeleteNewsAsync(int id);
        Task DeleteComentAsync(int id);
    }
}
