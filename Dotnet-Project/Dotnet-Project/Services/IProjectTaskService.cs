using Dotnet_Project.Models;

namespace Dotnet_Project.Services
{
    public interface IProjectTaskService
    {
        
            Task<IEnumerable<ProjectTask>> GetTasksByStatus(Status status);
            Task<bool> UpdateTaskStatus(int taskId, Status newStatus);
            Task<bool> CreateTask(ProjectTask task);
            Task<IEnumerable<Employee>> GetEmployees();


    }
}
