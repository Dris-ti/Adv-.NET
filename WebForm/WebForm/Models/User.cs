using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebForm.Models
{
	public class User
	{
        [Required, StringLength(20, ErrorMessage = "Name should not be more than 20 chars")]
        public string name{ get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string[] hobbies { get; set; }

    }
}