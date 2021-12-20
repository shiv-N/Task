using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IStudentRL
    {
        Task<PaginatedList<StudentCourse>> GetStudents(string sortOrder, string searchString,int pageNumber,int pageSize);

        Student CheckEmail(string email);

        bool Register(Student model);

        Student GetStudent(long id);

        bool updateStudent(Student student, Student newStudent);
    }
}
