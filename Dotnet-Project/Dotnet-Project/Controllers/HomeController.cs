using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics;

namespace Dotnet_Project.Controllers
{
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
            /*// Create a new Employee object (John Doe)
            var johnDoe = new Employee
            {
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
        

           

            // Create another Employee object (Jane Smith)
            var janeSmith = new Employee
            {
                Id = 2,
                Name = "Jane Smith",
                Department = "Design",
                Post = "UI/UX Designer",
                Email = "jane.smith@example.com",
                Image = "https://example.com/jane-smith.jpg",
                Phone = "987-654-3210",
                Gender = Gender.Female,
                Evaluation = Evaluation.Excellent
            };

            // Create the main model (John Doe) with tasks and feedbacks
            var model = new Employee
            {
                Id = 1,
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
                Tasks = new List<ProjectTask>
        {
            new ProjectTask
            {
                TaskId = 1,
                Title = "Implement Authentication",
                dueDate = DateTime.Now.AddDays(-5),
                Status = Status.InProgress,
                CreationDate = DateTime.Now.AddDays(-10),
                Description = "Implement user authentication using JWT."
            }
        },
                WrittenFeedbacks = new List<Feedback>
        {
            new Feedback
            {
                Id = 1,
                Date = DateTime.UtcNow.AddDays(-5),
                Description = "Great teamwork on the authentication feature!",
                WriterId = 1, // John Doe wrote this feedback
                Writer = johnDoe, // Populate the Writer navigation property
                ReceiverId = 2 // Feedback for Jane Smith
            }
        },
                ReceivedFeedbacks = new List<Feedback>
        {
            new Feedback
            {
                Id = 2,
                Date = DateTime.UtcNow.AddDays(-3),
                Description = "Excellent job on the database design!",
                WriterId = 2, // Jane Smith wrote this feedback
                Writer = janeSmith, // Populate the Writer navigation property
                ReceiverId = 1 // Feedback for John Doe
            }
        }
            };*/
            var project= _context.Projects
                                   .Include(e => e.TeamMembers)
                                   .Include(e => e.Tasks)
                                   .Include(e => e.Description)
                                   .FirstOrDefault();

            // Pass the model to the view
            return View("~/Views/ProjectOverview/Index.cshtml", project);
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
