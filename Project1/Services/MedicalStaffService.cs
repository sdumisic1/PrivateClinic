using System;
using Project1.Models;
using Project1.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.DTO;

namespace Project1.Services
{
    public class MedicalStaffService : IMedicalStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private IMapper _mapper;

        public MedicalStaffService(IStaffRepository staffRepository, IMapper mapper)
        {
            this._staffRepository = staffRepository;
            this._mapper = mapper;
        }

        public async Task<MedicalStaffDTO> CreateMedicalStaff(MedicalStaffDTO staff)
        {
            var staffToCreate = _mapper.Map<DTO.MedicalStaffDTO, MedicalStaff>(staff);
            var addedStaff = await _staffRepository.CreateStaff(staffToCreate);
            DTO.MedicalStaffDTO returnStaff = _mapper.Map<DTO.MedicalStaffDTO>(addedStaff);
            return returnStaff;
        }

        public async Task DeleteMedicalStaffDTO(int id)
        {
            await _staffRepository.DeleteStaff(id);
        }

        public async Task<MedicalStaffDTO> GetMedicalStaffByCode(string code)
        {
            var staff = await _staffRepository.GetStaffByCode(code);
            DTO.MedicalStaffDTO returnStaff = _mapper.Map<DTO.MedicalStaffDTO>(staff);
            return returnStaff;
        }

        public async Task<MedicalStaffDTO> GetMedicalStaffById(int id)
        {
            var staff = await _staffRepository.GetStaffById(id);
            DTO.MedicalStaffDTO returnStaff = _mapper.Map<DTO.MedicalStaffDTO>(staff);
            return returnStaff;
        }

        public async Task<IEnumerable<MedicalStaffDTO>> ListAsync()
        {
            var list = await _staffRepository.ListAsync();
            var returnList = _mapper.Map<IEnumerable<MedicalStaff>, IEnumerable<DTO.MedicalStaffDTO>>(list);
            return returnList;
        }

        public async Task<IEnumerable<MedicalStaffDTO>> GetAllDoctors()
        {
            var list = await _staffRepository.GetAllDoctors();
            var returnList = _mapper.Map<IEnumerable<MedicalStaff>, IEnumerable<DTO.MedicalStaffDTO>>(list);
            return returnList;
        }

        public async Task<MedicalStaffDTO> UpdateMedicalStaff(MedicalStaffDTO staff)
        {
            var staffToUpdate = _mapper.Map<DTO.MedicalStaffDTO, MedicalStaff>(staff);
            var updatedStaff = await _staffRepository.UpdateStaffDetails(staffToUpdate);
            DTO.MedicalStaffDTO returnStaff = _mapper.Map<DTO.MedicalStaffDTO>(updatedStaff);
            return returnStaff;
        }
    }
}
