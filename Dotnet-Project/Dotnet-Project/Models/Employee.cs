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

        // Feedbacks written by this employee
        public ICollection<Feedback> WrittenFeedbacks { get; set; } = new List<Feedback>();

        // Feedbacks received by this employee
        public ICollection<Feedback> ReceivedFeedbacks { get; set; } = new List<Feedback>();

        public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();


    }
}
