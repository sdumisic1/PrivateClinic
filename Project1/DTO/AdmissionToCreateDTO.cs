using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public class AdmissionToCreateDTO
    {
        public string DateAndTime { get; set; }
        public bool? IsEmergency { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public string Description { get; set; }
        public string DateAndTimeForReport { get; set; }
    }
}
