using Dotnet_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics;

namespace Dotnet_Project.Controllers
{
    [Authorize(Roles = "HR Manager, Project Manager")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            
            var project= _context.Projects
                                   .Include(e => e.TeamMembers)
                                   .Include(e => e.Tasks)
                                   .Include(e => e.Description)
                                   .FirstOrDefault();
           
            
            return View("Views/ProjectOverview/Index.cshtml", project);
        }
        public IActionResult test()
        {
            var model = new Project();
            model.startDate = DateTime.Now;
            model.endDate = DateTime.Now.AddDays(30);
            model.ProjectName = "Project 1";
            model.Description = new ProjectDescription { KeyFeatures = "This is a project", TechnologiesUsed="test" };
            model.Chef = new Employee { Name = "John Doe" };
            model.TeamMembers.Add(new Employee { Name = "Jane Doe" });
            model.TeamMembers.Add(new Employee { Name = "Alice" });
            model.TeamMembers.Add(new Employee { Name = "Bob" });
            model.Progress = Progress.Stage0;





            return View("~/Views/ProjectOverview/Index.cshtml",model);
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
