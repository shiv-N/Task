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

        public bool DeleteStudent(Student model)
        {
            try
            {
                List<StudentCourseCollab> studentCourses = (from SC in _context.StudentCourseCollab
                                                            where SC.Id == model.Id
                                                            select SC).ToList();
                                                            
                _context.StudentCourseCollab.RemoveRange(studentCourses);
                _context.Students.Remove(model);
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

        public Student GetStudent(long id)
        {
            try
            {
                return this._context.Students.First(x => x.Id == id);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public async Task<PaginatedList<StudentCourse>> GetStudents(string sortOrder, string searchString,
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


                var studentCourses =  (from S in students
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
                                                    });

                PaginatedList<StudentCourse> list = 
                    await PaginatedList<StudentCourse>.CreateAsync(studentCourses.AsNoTracking(), pageNumber, pageSize);
                
                return list;
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

        public bool updateStudent(Student student, Student newStudent)
        {
            try
            {
                student.FirstName = newStudent.FirstName;
                student.LastName = newStudent.LastName;
                student.EmailAddress = newStudent.EmailAddress;
                student.EnrollDate = newStudent.EnrollDate;
                student.ModifiedAt = DateTime.Now;
                int result = this._context.SaveChanges();

                if(result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
