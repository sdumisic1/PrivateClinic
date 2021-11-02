using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services
{
    public interface IAdmissionService
    {
        Task<IEnumerable<DTO.AdmissionDTO>> ListAsync();
        Task<IEnumerable<DTO.AdmissionDetailsDTO>> GetAllAdmissionsDetails();
        Task<IEnumerable<DTO.AdmissionDetailsDTO>> GetAllAdmissionsSearch(string start, string end);

        Task<DTO.AdmissionDetailsDTO> GetAdmissionDetailsById(int id);
        Task<DTO.AdmissionDTO> GetAdmissionById(int id);
        Task UpdateAdmission(DTO.AdmissionDTO admission);
        Task<DTO.AdmissionDTO> CreateAdmission(DTO.AdmissionDTO admission);
        Task CreateAdmissionAndReport(DTO.AdmissionToCreateDTO admission);
        Task DeleteAdmission(int id);
    }
}
