using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Request.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Request.Entity
{
    public class InspectionRequest
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "کد ملی باید 10 رقم باشد.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "کد ملی فقط باید شامل اعداد باشد.")]
        public string NationalId { get; set; }


        [Required(ErrorMessage = "شماره تماس الزامی است.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "شماره تماس باید 11 رقم باشد.")]
        public string PhoneNumber { get; set; }


        public DateTime Date { get; set; }
        [Required(ErrorMessage = "آدرس الزامی است.")]
        public string Address { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<CarModel> AvailableCarModels { get; set; }
    }
}
