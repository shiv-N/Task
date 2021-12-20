using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.ContextLayer
{
    public class StudentAppDbContext : DbContext
    {
        public StudentAppDbContext(DbContextOptions<StudentAppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseCollab> StudentCourseCollab { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();

            builder.Entity<StudentCourseCollab>().HasKey(sc => new { sc.Id, sc.CourseId });

            builder.Entity<StudentCourseCollab>()
                            .HasOne<Student>(sc => sc.Student)
                            .WithMany(s => s.StudentCourseCollab)
                            .HasForeignKey(sc => sc.Id);

            builder.Entity<StudentCourseCollab>()
                            .HasOne<Course>(sc => sc.Course)
                            .WithMany(s => s.StudentCourseCollab)
                            .HasForeignKey(sc => sc.CourseId);

            builder.Entity<Student>()
                .HasData(
                        new Student
                        {
                            Id = 1,
                            FirstName = "Shiv",
                            LastName = "Aanand",
                            EnrollDate = new DateTime(2021, 12, 12),
                            EmailAddress = "Shiv@gmail.com",
                            CreatedAt = DateTime.Now

                        },
                        new Student
                        {
                            Id = 2,
                            FirstName = "Latika",
                            LastName = "Aanand",
                            EnrollDate = new DateTime(2021, 12, 12),
                            EmailAddress = "Latika@gmail.com",
                            CreatedAt = DateTime.Now
                        }
                    );

            builder.Entity<Course>()
               .HasData(
                       new Course
                       {
                           CourseId = 1,
                           CourseName = "Physics",
                           CourseFee = 500,
                           CreateAt = DateTime.Now

                       },
                       new Course
                       {
                           CourseId = 2,
                           CourseName = "Chemistry",
                           CourseFee = 4500,
                           CreateAt = DateTime.Now
                       }
                   );

        }
    }
}
