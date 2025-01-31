namespace Dotnet_Project.Models
{
    // ApplicationDbContext
    using Microsoft.EntityFrameworkCore;
    using Dotnet_Project.Models;
    using Dotnet_Project.Migrations;
    using static System.Net.Mime.MediaTypeNames;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectDescription> ProjectDescriptions { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectTask>()
                    .ToTable("ProjectTasks");
            modelBuilder.Entity<Employee>()
                      .HasMany(e => e.Tasks)
                      .WithOne(t => t.Employee)
                      .HasForeignKey(t => t.EmployeeId);
            modelBuilder.Entity<Employee>()
                       .HasOne(t => t.Project)
                      .WithMany(p => p.TeamMembers)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
       .HasOne(p => p.Chef)  // Project has one Chef (Employee)
       .WithMany()  // Each Employee can be Chef for multiple Projects
       .HasForeignKey(p => p.ChefId)  // The foreign key in Project
       .OnDelete(DeleteBehavior.Restrict);
            // Configure relationships and other constraints if necessary
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(t => t.TaskId);
                entity.ToTable("ProjectTasks");

                // Relationship with Employee (Avoid Cascade Delete)
                entity.HasOne(t => t.Employee)
                      .WithMany(e => e.Tasks)
                      .HasForeignKey(t => t.EmployeeId)
                      .OnDelete(DeleteBehavior.Restrict); // Change from Cascade to Restrict

                // Relationship with Project (Avoid Cascade Delete)
                entity.HasOne(t => t.Project)
                      .WithMany(p => p.Tasks)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict); // Change from Cascade to Restrict

                // Set default value for CreationDate
                entity.Property(t => t.CreationDate)
                      .HasDefaultValueSql("GETDATE()");
            });
            modelBuilder.Entity<Project>()
                      .HasMany(e => e.Tasks)
                      .WithOne(t => t.Project)
                      .HasForeignKey(t => t.ProjectId)
                      .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Project>()
     .HasMany(p => p.TeamMembers) // A project has many employees
     .WithOne(e => e.Project)    // An employee has one project
     .HasForeignKey(e => e.ProjectId) // Foreign key in Employee table
     .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Project>()
    .HasOne(p => p.Description)
    .WithOne(d => d.Project)
    .HasForeignKey<ProjectDescription>(d => d.ProjectId) // Explicit foreign key
  .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Meeting>()
           .HasOne(m => m.Moderator)
           .WithMany()
           .HasForeignKey(m => m.ModeratorId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.Participant)
                .WithMany()
                .HasForeignKey(m => m.ParticipantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
               .HasOne(f => f.Writer)
               .WithMany(e => e.WrittenFeedbacks)
               .HasForeignKey(f => f.WriterId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.Receiver)
                .WithMany(e => e.ReceivedFeedbacks)
                .HasForeignKey(f => f.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = 1,
                  Name = "John Doe",
                  Department = "Engineering",
                  Post = "Developper",
                  Phone = "23456654",
                  Email = "johndoe@example.com",
                  Image = "/images/avatar.svg",
                  Gender = Gender.Male,
                  Evaluation = Evaluation.Excellent,
                  OverdueTasks = 4,
                  CompletedTasks = 5,
                  AbsenceDays = 20,
                  HoursWorked = 20,
                  ProjectId = 2

              },
              new Employee
              {
                  Id = 2,
                  Name = "Jane Smith",
                  Department = "Marketing",
                  Post = "UI/UX Designer",
                  Phone = "23456654",
                  Email = "janesmith@example.com",
                  Image = "/images/avatar.svg",
                  Gender = Gender.Male,
                  Evaluation = Evaluation.Excellent,
                  OverdueTasks = 4,
                  CompletedTasks = 5,
                  AbsenceDays = 20,
                  HoursWorked = 20,
                  ProjectId = 2

              },
              new Employee
              {
                  Id = 3,
                  Name = "Alice Johnson",
                  Department = "HR",
                  Post = "UI/UX Designer",
                  Phone = "23456654",
                  Email = "alicejohnson@example.com",
                  Image = "/images/avatar.svg",
                  Gender = Gender.Female,
                  Evaluation = Evaluation.Excellent,
                  OverdueTasks= 4,
                  CompletedTasks= 5,
                  AbsenceDays= 20,
                  HoursWorked= 20,
                  ProjectId = 2

              });
            modelBuilder.Entity<Meeting>().HasData(
                  new Meeting
                  {
                      Id = 1,
                      ParticipantId = 1,  
                      ModeratorId = 2,    
                      Date = new DateOnly(2025, 2, 1),  
                      Time = new TimeOnly(10, 0),       
                      Subject = "Project Kickoff"
                  },
                  new Meeting
                  {
                      Id = 2,
                      ParticipantId = 3,  
                      ModeratorId = 2,   
                      Date = new DateOnly(2025, 2, 3),  
                      Time = new TimeOnly(14, 30),      
                      Subject = "Quarterly Review"
                  },
                  new Meeting
                  {
                      Id = 3,
                      ParticipantId = 2,  // Referring to Employee with Id 2
                      ModeratorId = 1,    // Referring to Employee with Id 1
                      Date = new DateOnly(2025, 2, 5),  // Example date
                      Time = new TimeOnly(9, 15),       // Example time (9:15 AM)
                      Subject = "Marketing Strategy"
                  }
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
                    Description = "Fix the login page bug on the company website.",
                    ProjectId = 2

                },
                new ProjectTask
                {
                    TaskId = 2,
                    Title = "Update employee records",
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.NotStarted,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Update the records of all employees in the HR system.",
                    ProjectId = 2

                },
                new ProjectTask
                {
                    TaskId = 3,
                    Title = "Prepare financial report",
                    EmployeeId = 3,
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.Completed,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Prepare and submit the quarterly financial report to management.",
                    ProjectId = 2

                },
                new ProjectTask
                {
                    TaskId = 4,
                    Title = "Fix website bug",
                    dueDate = new DateTime(2024, 12, 31),
                    Status = Status.NotStarted,
                    CreationDate = new DateTime(2024, 12, 31),
                    Description = "Fix the login page bug on the company website.",
                    ProjectId = 2
                }
            );
            modelBuilder.Entity<Project>().HasData(
      new Project
      {
          Id = 2, // Project ID
          ProjectName = "ERP System Development",
          ChefId = 1, // Employee ID 1 as the Chef
          Progress = Progress.Stage2,
          startDate = new DateTime(2024, 10, 1),
          endDate = new DateTime(2025, 5, 30)
      });


            modelBuilder.Entity<ProjectDescription>().HasData(
     new ProjectDescription
     {
         Id = 3, // Description ID (must match ProjectId)
         ProjectId = 2, // Explicitly set the foreign key
         KeyFeatures = "Modular architecture, Role-based access, Multi-tenancy",
         TechnologiesUsed = "ASP.NET Core, Entity Framework, React"
     }
     );




            

        }

    }

}
