using Microsoft.AspNetCore.Mvc;
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
    }
}