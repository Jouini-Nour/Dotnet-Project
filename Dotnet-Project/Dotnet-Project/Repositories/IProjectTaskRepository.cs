using Dotnet_Project.Models;

namespace Dotnet_Project.Repositories
{
    public interface IProjectTaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetAllProjectTasksAsync();
        Task<ProjectTask> GetProjectTaskByIdAsync(int id);
        Task<ProjectTask> AddProjectTaskAsync(ProjectTask projectTask);
        Task<ProjectTask> UpdateProjectTaskAsync(ProjectTask projectTask);
        Task<bool> DeleteProjectTaskAsync(int id);
        Task UpdateAsync(ProjectTask task);
    }
}
