using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project1.Models
{
    public partial class MedicalStaff
    {
        public MedicalStaff()
        {
            Admission = new HashSet<Admission>();
        }

        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Admission> Admission { get; set; }
    }
}
