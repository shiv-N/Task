using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime EnrollDate { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        public DateTime? CreatedAt  { get; set; }
        public DateTime? ModifiedAt  { get; set; }

        public IList<StudentCourseCollab> StudentCourseCollab { get; set; }
    }
}
