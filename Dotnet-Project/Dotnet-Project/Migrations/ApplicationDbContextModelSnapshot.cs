﻿// <auto-generated />
using System;
using Dotnet_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dotnet_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dotnet_Project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Engineering",
                            Email = "johndoe@example.com",
                            Image = "https://example.com/images/johndoe.jpg",
                            Name = "John Doe",
                            Phone = "23456654"
                        },
                        new
                        {
                            Id = 2,
                            Department = "Marketing",
                            Email = "janesmith@example.com",
                            Image = "https://example.com/images/janesmith.jpg",
                            Name = "Jane Smith",
                            Phone = "23456654"
                        },
                        new
                        {
                            Id = 3,
                            Department = "HR",
                            Email = "alicejohnson@example.com",
                            Image = "https://example.com/images/alicejohnson.jpg",
                            Name = "Alice Johnson",
                            Phone = "23456654"
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("ModeratorId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ModeratorId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Meetings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(2025, 2, 1),
                            ModeratorId = 2,
                            ParticipantId = 1,
                            Subject = "Project Kickoff",
                            Time = new TimeOnly(10, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(2025, 2, 3),
                            ModeratorId = 2,
                            ParticipantId = 3,
                            Subject = "Quarterly Review",
                            Time = new TimeOnly(14, 30, 0)
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateOnly(2025, 2, 5),
                            ModeratorId = 1,
                            ParticipantId = 2,
                            Subject = "Marketing Strategy",
                            Time = new TimeOnly(9, 15, 0)
                        });
                });

            modelBuilder.Entity("Dotnet_Project.Models.ProjectTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId1")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dueDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Meeting", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Employee", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotnet_Project.Models.Employee", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Moderator");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Dotnet_Project.Models.ProjectTask", b =>
                {
                    b.HasOne("Dotnet_Project.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotnet_Project.Models.Employee", null)
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId1");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Dotnet_Project.Models.Employee", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
