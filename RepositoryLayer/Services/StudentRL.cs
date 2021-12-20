using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ContextLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class StudentRL : IStudentRL
    {
        private StudentAppDbContext _context;
        public StudentRL(StudentAppDbContext context)
        {
            this._context = context;
        }

        public Student CheckEmail(string email)
        {
            try
            {
                return _context.Students.FirstOrDefault(x => x.EmailAddress == email);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<StudentCourseList<StudentCourse>> GetStudents(string sortOrder, string searchString,
                                                            int pageNumber, int pageSize)
        {
            try
            {
                var students = from s in _context.Students
                               select s;

                if (!string.IsNullOrEmpty(searchString))
                {
                    students = students.Where(s => s.LastName.Contains(searchString)
                                           || s.EmailAddress.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        students = students.OrderByDescending(s => s.LastName);
                        break;
                    case "Date":
                        students = students.OrderBy(s => s.EnrollDate);
                        break;
                    case "date_desc":
                        students = students.OrderByDescending(s => s.EnrollDate);
                        break;
                    default:
                        students = students.OrderBy(s => s.LastName);
                        break;
                }

                PaginatedList<Student> list = await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber, pageSize);


                List<StudentCourse> studentCourses = (from S in list
                                                select new StudentCourse
                                                {
                                                    StudentId = S.Id,
                                                    FirstName = S.FirstName,
                                                    LastName = S.LastName,
                                                    EnrollDate = S.EnrollDate,
                                                    EmailAddress = S.EmailAddress,
                                                    CreatedAt = S.CreatedAt,
                                                    ModifiedAt = S.ModifiedAt,
                                                    Courses = (from SC in _context.StudentCourseCollab
                                                               join C in _context.Courses
                                                               on SC.Id equals S.Id
                                                               where SC.CourseId == C.CourseId
                                                               select new Course
                                                               {
                                                                   CourseName = C.CourseName,
                                                                   CourseFee = C.CourseFee,
                                                                   CourseId = C.CourseId,
                                                                   CreateAt = C.CreateAt,
                                                                   ModifiedAt = C.ModifiedAt
                                                               }).ToList()
                                                }).ToList();

                StudentCourseList<StudentCourse> result = StudentCourseList<StudentCourse>.Create(
                                                                            studentCourses,
                                                                            pageNumber,
                                                                            pageSize);

                return result;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool Register(Student model)
        {
            try
            {
                model.CreatedAt = DateTime.Now;
                _context.Students.Add(model);
                int result = _context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
