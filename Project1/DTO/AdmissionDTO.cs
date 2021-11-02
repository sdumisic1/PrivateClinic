using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public class AdmissionDTO
    {
        public int AdmissionId { get; set; }
        public string DateAndTime { get; set; }
        public bool? IsEmergency { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public int ReportId { get; set; }

    }
}
