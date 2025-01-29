using Microsoft.EntityFrameworkCore;
using Dotnet_Project.Models;
namespace Dotnet_Project.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectTaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectTask>> GetAllProjectTasksAsync()
        {
            return await _context.Set<ProjectTask>().Include(pt => pt.Employee).ToListAsync();
        }

        public async Task<ProjectTask> GetProjectTaskByIdAsync(int id)
        {
            return await _context.ProjectTasks.Include(p=>p.Employee).FirstOrDefaultAsync(pt => pt.TaskId == id);
        }

        public async Task<ProjectTask> AddProjectTaskAsync(ProjectTask projectTask)
        {
            _context.Set<ProjectTask>().Add(projectTask);
            await _context.SaveChangesAsync();
            return projectTask;
        }

        public async Task<ProjectTask> UpdateProjectTaskAsync(ProjectTask projectTask)
        {
            _context.Entry(projectTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return projectTask;
        }

        public async Task<bool> DeleteProjectTaskAsync(int id)
        {
            var projectTask = await _context.Set<ProjectTask>().FindAsync(id);
            if (projectTask == null)
                return false;

            _context.Set<ProjectTask>().Remove(projectTask);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task UpdateAsync(ProjectTask task)
        {
            _context.ProjectTasks.Update(task);
            await _context.SaveChangesAsync();
        }

    }
}
