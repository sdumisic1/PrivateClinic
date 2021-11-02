using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DTO
{
    public class PatientDTO
    {
        public int PatientId { get; set; }
        public string NameSurname { get; set; }
        public int Jmbg { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public IList<AdmissionDTO> Admissions { get; set; } = new List<AdmissionDTO>();
            }
}
