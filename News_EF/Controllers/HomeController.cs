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
        public IActionResult Add(News news)
        {
            servise.AddNews(news);

            return new RedirectToActionResult("index", "home", null);
                //$"Полученна строка {news.Id}\n{news.Title}\n{news.Text}\n{news.Author}\n{news.Date} ";
        }

        [HttpPost]
        [Route("home/addcoment")]
        public string AddComent(int newsid,string Author,string Text)
        {
             return servise.AddComent(newsid, Author,Text);
            //return $"Айди новости {newsid} Имя автора {Author} Текст коментария {Text} ";//RedirectToAction("read","home",new { id=newsid});
            
        }

        [HttpGet]
        [Route("home/read/{id:int?}")]
        public IActionResult Read(int id)
        {
             var news=servise.ShowNews(id);
            return View(news);
                //$"{id}";
        }


    }
}