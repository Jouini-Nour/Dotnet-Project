namespace Dotnet_Project.Models
{
    // ApplicationDbContext
    using Microsoft.EntityFrameworkCore;
    using Dotnet_Project.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and other constraints if necessary
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(t => t.TaskId);
                entity.ToTable("ProjectTasks");
                // Relationship with Employee
                entity.HasOne(t => t.Employee)
                      .WithMany(e => e.Tasks)
                        .HasForeignKey(t => t.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade);

                // Set default value for CreationDate
                entity.Property(t => t.CreationDate)
                      .HasDefaultValueSql("GETDATE()");
            });
           /* modelBuilder.Entity<Employee>().HasData(
                new Employee { Id=-1,Name= "Unassigned", Department=null,Email=null},
        new Employee { Id = 1, Name = "John Doe", Department = "IT", Email = "john.doe@example.com" },
        new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Email = "jane.smith@example.com" },
        new Employee { Id = 3, Name = "Sam Brown", Department = "Finance", Email = "sam.brown@example.com" }
    );

            // Seed ProjectTasks
            modelBuilder.Entity<ProjectTask>().HasData(
                new ProjectTask
                {
                    TaskId = 1,
                    Title = "Fix website bug",
                    EmployeeId = 1,
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.InProgress,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Fix the login page bug on the company website."
                },
                new ProjectTask
                {
                    TaskId = 2,
                    Title = "Update employee records",
                    EmployeeId = 2,
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.NotStarted,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Update the records of all employees in the HR system."
                },
                new ProjectTask
                {
                    TaskId = 3,
                    Title = "Prepare financial report",
                    EmployeeId = 3,
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.Completed,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Prepare and submit the quarterly financial report to management."
                },
                new ProjectTask
                {
                    TaskId = 4,
                    Title = "Fix website bug",
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.NotStarted,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Fix the login page bug on the company website."
                }
            );*/
        }
    }

}
