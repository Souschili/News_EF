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
            Database.EnsureCreated();
        }

    }
}
