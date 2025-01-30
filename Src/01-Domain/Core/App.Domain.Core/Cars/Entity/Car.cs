using App.Domain.Core.Cars.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Cars.Entity
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "بخش اول پلاک خودرو الزامی است.")]
        [StringLength(2, MinimumLength = 2)]
        [LicensePlatePart1Validation]
        public string LicensePlatePart1 { get; set; }

        [Required(ErrorMessage = "حرف پلاک خودرو الزامی است.")]
        public string LicensePlateLetter { get; set; }

        [Required(ErrorMessage = "بخش دوم پلاک خودرو الزامی است.")]
        [StringLength(3, MinimumLength = 3)]
        [LicensePlatePart2Validation]
        public string LicensePlatePart2 { get; set; }

        [Required(ErrorMessage = "بخش سوم پلاک خودرو الزامی است.")]
        [StringLength(2, MinimumLength = 2)]
        [LicensePlatePart3Validation]
        public string LicensePlatePart3 { get; set; }

        [Required(ErrorMessage = "مدل خودرو الزامی است.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "سال تولید خودرو الزامی است.")]
        public int ProductionYear { get; set; }

        [Required(ErrorMessage = "شرکت سازنده خودرو الزامی است.")]
        public string Manufacturers { get; set; }

        [NotMapped]
        public string LicensePlate
        {
            get
            {
                return LicensePlatePart1 + " " + LicensePlateLetter + " " + LicensePlatePart2 + " ایران " + LicensePlatePart3;
            }
            private set { }
        }
    }
}
