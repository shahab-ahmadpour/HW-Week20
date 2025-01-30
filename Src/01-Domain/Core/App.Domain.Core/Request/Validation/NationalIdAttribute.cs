using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Validation
{
    public class NationalIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string nationalId = value as string;

            if (string.IsNullOrEmpty(nationalId))
            {
                return new ValidationResult("کد ملی نمی‌تواند خالی باشد.");
            }

            if (nationalId.Length != 10)
            {
                return new ValidationResult("کد ملی باید دقیقاً 10 رقم باشد.");
            }

            if (!long.TryParse(nationalId, out _))
            {
                return new ValidationResult("کد ملی باید فقط شامل اعداد باشد.");
            }

            return ValidationResult.Success;
        }
    }
}
