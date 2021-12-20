using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class StudentCourse
    {
        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollDate { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public List<Course> Courses { get; set; }
    }
    public class StudentCourseList<T> : PaginatedList<T>
    {
        public StudentCourseList(List<T> items, int count, int pageIndex, int pageSize) 
                                                    : base(items, count, pageIndex, pageSize)
        {
           
        }

        public static StudentCourseList<T> Create(List<T> items, int pageIndex, int pageSize)
        {
            var count =  items.Count();
            var item =  items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return  new StudentCourseList<T>(items, count, pageIndex, pageSize);
        }

    }

}
