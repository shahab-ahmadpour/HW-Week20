using App.Domain.Core.Cars.Entity;
using App.Domain.Core.Request.Enums;
using App.Domain.Core.Request.Validation;
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

        [Required(ErrorMessage = "شماره تماس الزامی است.")]
        [StringLength(11, MinimumLength = 11)]
        [PhoneNumber]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "کد ملی الزامی است.")]
        [StringLength(10, MinimumLength = 10)]
        [NationalId]
        public string NationalId { get; set; }

        public DateTime Date { get; set; }
        [Required(ErrorMessage = "آدرس الزامی است.")]
        public string Address { get; set; }

        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public int CarId { get; set; }
        public Car Car { get; set; }

        public List<CarModel> AvailableCarModels { get; set; }
    }
}
