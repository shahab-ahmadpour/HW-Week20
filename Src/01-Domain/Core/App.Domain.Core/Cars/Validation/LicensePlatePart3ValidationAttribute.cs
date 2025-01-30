using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Validation
{
    public class LicensePlatePart3ValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = value as string;
            if (string.IsNullOrEmpty(input) || input.Length != 2 || !int.TryParse(input, out _))
            {
                return new ValidationResult("بخش چهارم پلاک باید 2 رقم عددی باشد.");
            }
            return ValidationResult.Success;
        }
    }
}
