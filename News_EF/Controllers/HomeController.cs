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
        public async Task<IActionResult> AddAsync(News news)
        {
            await servise.AddNewsAsync(news);

            return new RedirectToActionResult("index", "home", null);
                //$"Полученна строка {news.Id}\n{news.Title}\n{news.Text}\n{news.Author}\n{news.Date} ";
        }

        [HttpPost]
        [Route("home/addcoment")]
        public async Task<IActionResult> AddComent (int newsid,string Author,string Text)
        {
            bool status=await servise.AddComentAsync(newsid, Author,Text);
            //в зависимости от статуса перекидываем на нужную страницу
            return status?new RedirectToActionResult("read", "home", new { id = newsid }):
                           new RedirectToActionResult("errordb","home",null);
        }



        [HttpGet]
        [Route("home/read/{id:int?}")]
        public async Task<IActionResult> Read(int id)
        {
            var n = await servise.ShowNewsAsync(id);
            if (n == null) return new RedirectToActionResult("error", "home", null);
            return View(n);
               
        }
        [HttpGet]
        [Route("home/deletenews/{id:int?}")]
        public async Task<IActionResult> DeleteNews  (int id)
        {
            var status=await servise.DeleteNewsAsync(id);
            return status?new RedirectToActionResult("index", "home", null):
                          new RedirectToActionResult("errordb","home",null);
        }

        [HttpGet]
        [Route("home/deletecoment")]
        public async Task<IActionResult> DeleteComent(int id,int newsid)
        {
           bool status= await servise.DeleteComentAsync(id);
            return status? new RedirectToActionResult("read", "home", new { id = newsid }):
                           new RedirectToActionResult("errordb", "home", null);
        }
        
        [HttpGet]
        [Route("/error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        [Route("/errorDB")]
        public IActionResult ErrorDB()
        {
            return View();
        }
    }
}