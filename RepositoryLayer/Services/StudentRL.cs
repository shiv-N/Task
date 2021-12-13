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

        public List<Student> GetStudents(string sortOrder)
        {
            try
            {
                var students = from s in _context.Students
                               select s;

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
                return students.ToList();
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
