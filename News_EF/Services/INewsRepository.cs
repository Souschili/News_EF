using News_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Services
{
    public interface INewsRepository
    {
        IEnumerable<News> GetNews();

    }
}
