using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Log.Entity
{
    public class InspectionLog
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
    }
}
