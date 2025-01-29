using Dotnet_Project.Views.Home;

namespace Dotnet_Project.Models
{
    public class TaskBoardViewModel
    {
        public IEnumerable<ProjectTask> UnassignedTasks { get; set; } = Enumerable.Empty<ProjectTask>();
        public IEnumerable<ProjectTask> InProgressTasks { get; set; } = Enumerable.Empty<ProjectTask>();
        public IEnumerable<ProjectTask> CompletedTasks { get; set; } = Enumerable.Empty<ProjectTask>();
        public IEnumerable<Employee> EmployeeList { get; set; } = new List<Employee>();

        public ProjectTask NewTask { get; set; } = new ProjectTask();
    }

}
