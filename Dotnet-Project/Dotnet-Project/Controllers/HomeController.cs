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
            var model =
            new Employee
            {
                Id = 1,
                Name = "John Doe",
                Department = "Engineering",
                Post = "Developper",
                Phone = "23456654",
                Email = "johndoe@example.com",
                Image = "https://example.com/images/johndoe.jpg",
                Gender = Gender.Male,
                Evaluation = Evaluation.Excellent,
                OverdueTasks = 4,
                CompletedTasks = 5,
                AbsenceDays = 20,
                HoursWorked = 20,
            };
            
            
            return View("Views/Profile/Index.cshtml", model);
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
