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

        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Meeting> Meetings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and other constraints if necessary
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(t => t.TaskId);

                // Relationship with Employee
                entity.HasOne(t => t.Employee)
                      .WithMany()
                      .HasForeignKey(t => t.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Set default value for CreationDate
                entity.Property(t => t.CreationDate)
                      .HasDefaultValueSql("GETDATE()");
            });

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

            modelBuilder.Entity<Employee>().HasData(
               new Employee
               {
                   Id = 1,
                   Name = "John Doe",
                   Department = "Engineering",
                   Phone = "23456654",
                   Email = "johndoe@example.com",
                   Image = "https://example.com/images/johndoe.jpg"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Jane Smith",
                   Department = "Marketing",
                   Phone = "23456654",
                   Email = "janesmith@example.com",
                   Image = "https://example.com/images/janesmith.jpg"
               },
               new Employee
               {
                   Id = 3,
                   Name = "Alice Johnson",
                   Department = "HR",
                   Phone = "23456654",
                   Email = "alicejohnson@example.com",
                   Image = "https://example.com/images/alicejohnson.jpg"
               });
            modelBuilder.Entity<Meeting>().HasData(
           new Meeting
           {
               Id = 1,
               ParticipantId = 1,  // Referring to Employee with Id 1
               ModeratorId = 2,    // Referring to Employee with Id 2
               Date = new DateOnly(2025, 2, 1),  // Example date
               Time = new TimeOnly(10, 0),       // Example time (10:00 AM)
               Subject = "Project Kickoff"
           },
           new Meeting
           {
               Id = 2,
               ParticipantId = 3,  // Referring to Employee with Id 3
               ModeratorId = 2,    // Referring to Employee with Id 4
               Date = new DateOnly(2025, 2, 3),  // Example date
               Time = new TimeOnly(14, 30),      // Example time (2:30 PM)
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
        
    }
    }
    

}
