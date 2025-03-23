using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task2_WebForm.Models
{
	public class Student
	{
        [Required]
        [RegularExpression(@"^[A-Za-z.\- ]+$")]
        public string name { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{2}\-[0-9]{5}\-[1-3]{1}$")]
        public string id { get; set; }
        [Required]
        [CustomDoBValidation]
        public DateTime DoB { get; set; }
        [Required]
        [CustomEmailValidation]       
        public string email { get; set; }
    }
}