using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Project1.Models
{
    public partial class Report
    {
        public Report()
        {
            Admission = new HashSet<Admission>();
        }

        public int ReportId { get; set; }
        public string Description { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual ICollection<Admission> Admission { get; set; }
    }
}
