using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using prjAjaxDemo.Models;
using System.Composition.Hosting.Core;
using System.Configuration;
using System.Diagnostics;

namespace prjAjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext _context;
        public HomeController(ILogger<HomeController> logger,MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var id = _context.Categories.Where(p => p.CategoryId ==1);
            return View();
        }
        public IActionResult First1()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult CallApi ()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult about()
        {   
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }*/);
        }

        public IActionResult JSONtest()
        {
            return View();
        }
        public IActionResult Homework1() 
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Spots()
        {
            return View();
        }

    }
}
