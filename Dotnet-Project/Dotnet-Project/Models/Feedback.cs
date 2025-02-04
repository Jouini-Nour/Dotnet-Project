namespace Dotnet_Project.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;

        // The employee who wrote the feedback
        public int WriterId { get; set; }
        public virtual Employee Writer { get; set; }

        // The employee who received the feedback
        public int ReceiverId { get; set; }
        public Employee Receiver { get; set; }
    }
}
