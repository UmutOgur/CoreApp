using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;

        private DataContext context;


        public HomeController(IConfiguration _configuration, DataContext context)
        {
            Configuration = _configuration;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRequest(Request model)
        {
            context.Requests.Add(model);
            context.SaveChanges();

            return View("Thanks", model);
        }

        public IActionResult List()
        {
            
            return View(context.Requests.OrderByDescending(y=>y.name)); //isme göre desc yapma
        }


    }
}
