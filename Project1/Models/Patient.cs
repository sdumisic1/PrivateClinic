using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project1.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Admission = new HashSet<Admission>();
        }

        public int PatientId { get; set; }
        public string NameSurname { get; set; }
        public long Jmbg { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Admission> Admission { get; set; }
    }
}
