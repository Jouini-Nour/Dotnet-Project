namespace Dotnet_Project.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public int ModeratorId { get; set; }
        public Employee Participant { get; set; }

        public Employee Moderator { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }
        public string? Subject { get; set; }
    }
}
