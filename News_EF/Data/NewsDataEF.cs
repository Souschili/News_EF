using Microsoft.EntityFrameworkCore;
using News_EF.Models;

namespace News_EF.Data
{
    public class NewsDataEF:DbContext
    {
        public DbSet<News> News { get; set; }

        //Пометка:
        public NewsDataEF(DbContextOptions<NewsDataEF> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
