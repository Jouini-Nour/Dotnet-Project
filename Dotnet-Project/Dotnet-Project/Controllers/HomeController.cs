using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dotnet_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model=new Employee();
            model.Name = "John";
            model.Department = "IT";
            model.Post = "Developer";
            
            
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult tasks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
