﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepositoryLayer.ContextLayer;

namespace RepositoryLayer.Migrations
{
    [DbContext(typeof(StudentAppDbContext))]
    [Migration("20211214045821_M3")]
    partial class M3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepositoryLayer.Entity.Course", b =>
                {
                    b.Property<long>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseFee")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1L,
                            CourseFee = 500,
                            CourseName = "Physics",
                            CreateAt = new DateTime(2021, 12, 14, 10, 28, 19, 813, DateTimeKind.Local).AddTicks(9076)
                        },
                        new
                        {
                            CourseId = 2L,
                            CourseFee = 4500,
                            CourseName = "Chemistry",
                            CreateAt = new DateTime(2021, 12, 14, 10, 28, 19, 814, DateTimeKind.Local).AddTicks(438)
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EnrollDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2021, 12, 14, 10, 28, 19, 805, DateTimeKind.Local).AddTicks(9452),
                            EmailAddress = "Shiv@gmail.com",
                            EnrollDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Shiv",
                            LastName = "Aanand"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2021, 12, 14, 10, 28, 19, 810, DateTimeKind.Local).AddTicks(4177),
                            EmailAddress = "Latika@gmail.com",
                            EnrollDate = new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Latika",
                            LastName = "Aanand"
                        });
                });

            modelBuilder.Entity("RepositoryLayer.Entity.StudentCourseCollab", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourseCollab");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.StudentCourseCollab", b =>
                {
                    b.HasOne("RepositoryLayer.Entity.Course", "Course")
                        .WithMany("StudentCourseCollab")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepositoryLayer.Entity.Student", "Student")
                        .WithMany("StudentCourseCollab")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Course", b =>
                {
                    b.Navigation("StudentCourseCollab");
                });

            modelBuilder.Entity("RepositoryLayer.Entity.Student", b =>
                {
                    b.Navigation("StudentCourseCollab");
                });
#pragma warning restore 612, 618
        }
    }
}
