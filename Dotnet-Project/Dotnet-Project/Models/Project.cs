namespace Dotnet_Project.Models
{
    public enum Progress
    {
        Stage0,
        Stage2,
        Stage3,
        Stage4
    }

    public class Project
    {
        public int Id { get; set; }
        public Employee Chef { get; set; }
        public string ProjectName { get; set; }
        public ProjectDescription Description { get; set; }
        public Progress Progress { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public ICollection<Employee> TeamMembers { get; set; } = new List<Employee>();


    }
}
