using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using SHF.Helper;

namespace SHF.Helpers
{
    public class RequiredField : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.IsNotNull())
            {
                string required = value.ToString();

                //if (Regex.IsMatch(required, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                //{
                //    return ValidationResult.Success;
                //}
                //else
                //{
                //    return new ValidationResult("Please Enter a Valid Email.");
                //}
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The " + validationContext.DisplayName + " is required.");
            }

            //return base.IsValid(value, validationContext);
        }
    }
}