using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News_EF.Services;

namespace News_EF.Controllers
{
    
    public class HomeController : Controller
    {
        private INewsRepository _repository;

        public HomeController(INewsRepository repo)
        {
            _repository = repo;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_repository.GetNews());
        }
    }
}