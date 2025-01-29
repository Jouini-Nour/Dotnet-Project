namespace Dotnet_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Post { get; set; }

        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

    }
}
