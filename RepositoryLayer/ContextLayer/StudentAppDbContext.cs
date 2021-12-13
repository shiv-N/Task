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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>()
                .HasIndex(u => u.EmailAddress)
                .IsUnique();


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
        }
    }
}
