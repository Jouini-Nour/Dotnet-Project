namespace Dotnet_Project.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Evaluation
    {
        Excellent,
        Good,
        Average,
        Poor
    }

    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Post { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? Phone { get; set; }
        public int? OverdueTasks { get; set; }
        public int? CompletedTasks { get; set; }
        public int? AbsenceDays { get; set; }
        public int? HoursWorked { get; set; }




        public Gender Gender { get; set; }
        public Evaluation Evaluation { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

        // Feedbacks written by this employee
        public ICollection<Feedback> WrittenFeedbacks { get; set; } = new List<Feedback>();

        // Feedbacks received by this employee
        public ICollection<Feedback> ReceivedFeedbacks { get; set; } = new List<Feedback>();

        public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}
