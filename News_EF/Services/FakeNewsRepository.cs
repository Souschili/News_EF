using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News_EF.Models;

namespace News_EF.Services
{
    public class FakeNewsRepository : INewsRepository
    {
        private List<News> ListNews = new List<News>
        {
            new News{Id=1,Title="First news",Text="This is my first news",Author="Dylan"},
            new News{Id=1,Title="Second news",Text="This is my second news",Author="Hunt"}
        };

        public IEnumerable<News> GetNews()
        {
            return ListNews;
        }
    }
}
