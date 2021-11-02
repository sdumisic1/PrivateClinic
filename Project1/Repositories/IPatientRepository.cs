using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<Patient> GetPatientById(int id);
        Task<Patient> GetPatientByJMBG(long jmbg);
        Task<Patient> UpdatePatientDetails(Patient patient);
        Task<Patient> CreatePatient(Patient patient);
        Task DeletePatient(int id);

    }
}
