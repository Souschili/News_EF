using Microsoft.EntityFrameworkCore;
using News_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Data
{
    public class NewsContext:DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Comments> Coments { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options):base(options)
        {
            //так как использую команды то это отключил 
           //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //хотел добавить каскадное удаление ,но как оказалось оно автоматом включенно
        }
    }
}
