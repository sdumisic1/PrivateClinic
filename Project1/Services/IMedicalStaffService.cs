using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services
{
    public interface IMedicalStaffService
    {
        Task<IEnumerable<DTO.MedicalStaffDTO>> ListAsync();
        Task<IEnumerable<DTO.MedicalStaffDTO>> GetAllDoctors();
        Task<DTO.MedicalStaffDTO> GetMedicalStaffById(int id);
        Task<DTO.MedicalStaffDTO> GetMedicalStaffByCode(string code);
        Task<DTO.MedicalStaffDTO> UpdateMedicalStaff(DTO.MedicalStaffDTO staff);
        Task<DTO.MedicalStaffDTO> CreateMedicalStaff(DTO.MedicalStaffDTO staff);
        Task DeleteMedicalStaffDTO(int id);
    }
}
