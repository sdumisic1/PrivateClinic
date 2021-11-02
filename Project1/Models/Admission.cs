using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project1.Models
{
    public partial class Admission
    {
        public int AdmissionId { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool? IsEmergency { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }
        public int? ReportId { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Report Report { get; set; }
        public virtual MedicalStaff Staff { get; set; }
    }
}
