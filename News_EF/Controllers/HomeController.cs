using Microsoft.AspNetCore.Mvc;

namespace News_EF.Controllers
{

    public class HomeController : Controller
    {
      

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}