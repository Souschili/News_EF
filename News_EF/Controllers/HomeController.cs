using Microsoft.AspNetCore.Mvc;
using News_EF.Models;
using News_EF.Services;
using System.Threading.Tasks;

namespace News_EF.Controllers
{

    public class HomeController : Controller
    {
        private INewsService servise;

        public HomeController(INewsService serv)
        {
            servise = serv;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await servise.GetNewsAsync());
        }

        [HttpPost]
        [Route("home/add")]
        public string Add(News news)
        {
            return $"Полученна строка {news.Id}\n{news.Title}\n{news.Text}\n{news.Author}\n{news.Date} ";
        }
    }
}