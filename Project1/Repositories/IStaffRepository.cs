using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.Repositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<MedicalStaff>> ListAsync();
        Task<IEnumerable<MedicalStaff>> GetAllDoctors();
        Task<MedicalStaff> GetStaffById(int id);
        Task<MedicalStaff> GetStaffByCode(string code);
        Task<MedicalStaff> UpdateStaffDetails(MedicalStaff staff);
        Task<MedicalStaff> CreateStaff(MedicalStaff staff);
        Task DeleteStaff(int id);
    }
}
