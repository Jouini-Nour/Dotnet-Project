namespace Dotnet_Project.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        
        public ICollection<Task> Tasks { get; set; } = new List<Task>();
        
    }
}
