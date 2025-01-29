using System.Threading.Tasks;
using Dotnet_Project.Models;
using Dotnet_Project.Repositories;
using Dotnet_Project.Services;
using Dotnet_Project.Views.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly IProjectTaskService _taskService;
        private readonly IProjectTaskRepository _taskRepository;
        private readonly ApplicationDbContext _context;

        public ProjectTaskController(IProjectTaskService taskService, IProjectTaskRepository taskRepository, ApplicationDbContext context)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var unassignedTasks = await _taskService.GetTasksByStatus(Status.NotStarted);
            var inProgressTasks = await _taskService.GetTasksByStatus(Status.InProgress);
            var completedTasks = await _taskService.GetTasksByStatus(Status.Completed);

            var viewModel = new TaskBoardViewModel
            {
                UnassignedTasks = unassignedTasks ?? Enumerable.Empty<ProjectTask>(),
                InProgressTasks = inProgressTasks ?? Enumerable.Empty<ProjectTask>(),
                CompletedTasks = completedTasks ?? Enumerable.Empty<ProjectTask>(),
                EmployeeList = await _taskService.GetEmployees(),
                NewTask = new ProjectTask()
            };

            

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskBoardViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    

                    model.EmployeeList = await _taskService.GetEmployees();
                    return View("Index", model);
                }
               
                var newTask = model.NewTask;
                newTask.CreationDate = DateTime.Now;
                newTask.Status = newTask.EmployeeId==-1 ? Status.NotStarted : Status.InProgress;

                var success = await _taskService.CreateTask(newTask);

                TempData["Success"] = success ? "Task created successfully!" : "Failed to create task. Please try again.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An unexpected error occurred. Please try again.";
                return RedirectToAction("Index");
            }
        }


        [HttpGet("ProjectTask/Details/{taskId}")]
        public async Task<IActionResult> Details(int taskId)
        {
            Console.WriteLine("lol");
            var task = await _taskRepository.GetProjectTaskByIdAsync(taskId);
            if (task == null)
            {
                return NotFound();
            }

            return Json(new
            {
                taskId = task.TaskId,
                title = task.Title,
                description = task.Description,
                employeeName = task.Employee != null ? task.Employee.Name : "Unassigned",
                status = task.Status.ToString(),
                creationDate = task.CreationDate,
                dueDate = task.dueDate
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string title, string description, int? employeeId, DateTime dueDate)
        {
            try
            {
                var task = await _context.ProjectTasks.FindAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                task.Title = title;
                task.Description = description;
                task.EmployeeId = employeeId; // Can be null
                task.dueDate = dueDate;
                task.Status = task.EmployeeId == -1 ? Status.NotStarted : Status.InProgress;
                _context.Update(task);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the error
                return View(nameof(Index));
            }
        }
        // Add these methods to your ProjectTaskController class

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            try
            {
                var task = await _context.ProjectTasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                task.Status = Status.Completed;
                _context.Update(task);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while completing the task");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var task = await _context.ProjectTasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                _context.ProjectTasks.Remove(task);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, "An error occurred while deleting the task");
            }
        }
    }

}
