using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2_WebForm.Models
{
	public class CustomEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Email is required");
            }
            var email = value.ToString();
            var s = validationContext.ObjectInstance as Student;
            var id = s.id.ToString();

            var idPart = email.ToString().Split('@');
            if (!idPart[0].Equals(id))
            {
                return new ValidationResult("Email must start with your ID");
            }

            if(!idPart[1].Equals("student.aiub.edu"))
            {
                return new ValidationResult("Email must end with @student.aiub.edu");
            }

            return ValidationResult.Success;
        }      
    }
}