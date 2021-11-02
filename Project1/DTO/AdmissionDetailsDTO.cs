using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public class AdmissionDetailsDTO
    {
        public int AdmissionId { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool? IsEmergency { get; set; }
        public int PatientId { get; set; }
        public string NameSurname { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffSurname { get; set; }
        public string StaffCode { get; set; }
        public int? ReportId { get; set; }
    }
}
