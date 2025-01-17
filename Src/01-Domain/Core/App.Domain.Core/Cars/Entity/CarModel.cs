using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Entity
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "نام مدل الزامی است.")]
        public string Name { get; set; }
    }
}
