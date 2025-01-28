using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dotnet_Project.Models
{

    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        // Navigation property for the related employee
        public Employee? Employee { get; set; }
        public DateTime dueDate { get; set; }
        public enum Status { NotStarted, InProgress, Completed }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        
    }
}
