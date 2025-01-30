using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string phoneNumber = value as string;

            if (string.IsNullOrEmpty(phoneNumber))
            {
                return new ValidationResult("شماره موبایل نمی‌تواند خالی باشد.");
            }

            if (!phoneNumber.StartsWith("09") || phoneNumber.Length != 11)
            {
                return new ValidationResult("شماره موبایل باید با 09 شروع شده و 11 رقم باشد.");
            }

            if (!long.TryParse(phoneNumber, out _))
            {
                return new ValidationResult("شماره موبایل باید فقط شامل اعداد باشد.");
            }

            return ValidationResult.Success;
        }
    }
}
