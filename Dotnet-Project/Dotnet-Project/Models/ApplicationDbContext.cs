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
        }
    }

}
