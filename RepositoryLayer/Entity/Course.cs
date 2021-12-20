using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CourseId { get; set; }

        public string CourseName { get; set; }

        public int CourseFee { get; set; }

        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public IList<StudentCourseCollab> StudentCourseCollab { get; set; }
    }

    public class StudentCourseCollab
    {
        public long Id { get; set; }
        public Student Student { get; set; }

        public long CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
