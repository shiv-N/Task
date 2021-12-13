using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCourseApp.Models
{
    public class StudentModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        //[Unique(typeof(Email))]
        [Required]
        public Email EmailAddress { get; set; }
    }

    public class Email
    {
        public string EmailId { get; set; }
    }

    public class Unique : ValidationAttribute
    {
        private IStudentRL _studentRL;
        public Unique(IStudentRL studentRL)
        {
            this._studentRL = studentRL;
        }
        public Type ObjectType { get; private set; }
        public Unique(Type type)
        {
            ObjectType = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Email should not be null");
            }

            if (ObjectType == typeof(Email))
            {
                
                //var email = _studentRL.CheckEmail(((Email)value).EmailId);
                var email = _studentRL.CheckEmail(((Email)value).EmailId);

                if (string.IsNullOrEmpty(email.EmailAddress))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("Mail already exists");
            }

            return new ValidationResult("Generic Validation Fail");
        }
    }
}
