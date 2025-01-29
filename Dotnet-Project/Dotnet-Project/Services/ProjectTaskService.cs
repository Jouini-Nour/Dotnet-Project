using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using static Dotnet_Project.Models.ProjectTask;
namespace Dotnet_Project.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksByStatus(Status status)
        {
            return await _context.ProjectTasks
                .Include(t => t.Employee)
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<bool> UpdateTaskStatus(int taskId, Status newStatus)
        {
            var task = await _context.ProjectTasks.FindAsync(taskId);
            if (task == null) return false;

            task.Status = newStatus;
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<bool> CreateTask(ProjectTask task)
        {
            try
            {
                task.CreationDate = DateTime.Now;
                if (task.EmployeeId != -1) { task.Status = Status.InProgress; }
                else { task.Status = Status.NotStarted; }
                _context.ProjectTasks.Add(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
