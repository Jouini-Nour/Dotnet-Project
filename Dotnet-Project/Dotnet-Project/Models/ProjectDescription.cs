namespace Dotnet_Project.Models
{
    public class ProjectDescription 
    {
        public int Id { get; set; } // Primary Key
        public int ProjectId { get; set; } // Foreign Key
        public string KeyFeatures { get; set; }
        public string TechnologiesUsed { get; set; }

        // Navigation Property
        public Project Project { get; set; }


    }
}
