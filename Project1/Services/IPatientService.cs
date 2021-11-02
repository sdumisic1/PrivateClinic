using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<DTO.PatientDTO>> ListAsync();
        Task<DTO.PatientDTO> GetPatientById(int id);
        Task<DTO.PatientDTO> GetPatientByJMBG(long jmbg);
        Task<DTO.PatientDTO> UpdatePatient(DTO.PatientDTO patient);
        Task<DTO.PatientDTO> CreatePatient(DTO.PatientDTO patient);
        Task DeletePatient(int id);

    }
}
