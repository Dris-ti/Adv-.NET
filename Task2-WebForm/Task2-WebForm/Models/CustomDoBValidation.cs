using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Task2_WebForm.Models
{
	public class CustomDoBValidation: ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var DoB = (DateTime)value;
            var diff = DateTime.Now.Year - DoB.Year;
            if (diff > 18) {
                return true;
            }
            return false;
        }
    }
}