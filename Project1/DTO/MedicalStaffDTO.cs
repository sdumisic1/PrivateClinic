using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public class MedicalStaffDTO
    {
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public TitleEnum Title { get; set; }
        public string Code { get; set; }
        public IList<AdmissionDTO> Admissions { get; set; } = new List<AdmissionDTO>();

    }
}
