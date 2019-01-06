using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News_EF.Data;

namespace News_EF.Controllers
{

    public class HomeController : Controller
    {
        private NewsDataEF db;
        public HomeController(NewsDataEF context)
        {
            db = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View( db.News.ToList());
        }
    }
}