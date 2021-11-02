using System;
using System.Collections.Generic;
using System.Linq;
using Project1.Repositories;
using System.Threading.Tasks;
using AutoMapper;
using Project1.Models;
using Project1.DTO;

namespace Project1.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _admissionRepository;
        private readonly IReportRepository _reportRepository;

        private IMapper _mapper;

        public AdmissionService(IAdmissionRepository admissionRepository, IReportRepository reportRepository, IMapper mapper)
        {
            this._admissionRepository = admissionRepository;
            this._reportRepository = reportRepository;
            this._mapper = mapper;
        }

        public async Task<AdmissionDTO> CreateAdmission(AdmissionDTO admission)
        {
            var admissionToCreate = _mapper.Map<DTO.AdmissionDTO, Admission>(admission);
            var addedAdmission = await _admissionRepository.CreateAdmission(admissionToCreate);
            DTO.AdmissionDTO returnAdmission = _mapper.Map<DTO.AdmissionDTO>(addedAdmission);
            return returnAdmission;
        }
        public async Task CreateAdmissionAndReport(DTO.AdmissionToCreateDTO admission)
        {
            var reportToCreate = _mapper.Map<DTO.AdmissionToCreateDTO, Report>(admission);
            var createdReport = await _reportRepository.CreateReport(reportToCreate);
            Admission admissionToCreate = new Admission()
            {
                DateAndTime = DateTime.Parse(admission.DateAndTime),
                IsEmergency = admission.IsEmergency,
                PatientId = admission.PatientId,
                StaffId = admission.StaffId,
                ReportId = createdReport.ReportId
            };
           
            await _admissionRepository.CreateAdmission(admissionToCreate);
        }


        public async Task DeleteAdmission(int id)
        {
            await _admissionRepository.DeleteAdmission(id);
        }

        public async Task<AdmissionDTO> GetAdmissionById(int id)
        {
            var admission = await _admissionRepository.GetAdmissionById(id);
            DTO.AdmissionDTO returnAdmission = _mapper.Map<DTO.AdmissionDTO>(admission);
            return returnAdmission;
        }
        public async Task<AdmissionDetailsDTO> GetAdmissionDetailsById(int id)
        {
            var admission = await _admissionRepository.GetAdmissionDetailsById(id);
            DTO.AdmissionDetailsDTO returnAdmission = _mapper.Map<DTO.AdmissionDetailsDTO>(admission);
            return returnAdmission;
        }

        public async Task<IEnumerable<AdmissionDTO>> ListAsync()
        {
            var list = await _admissionRepository.ListAsync();
            var returnList = _mapper.Map<IEnumerable<Admission>, IEnumerable<DTO.AdmissionDTO>>(list);
            return returnList;
        }
        public async Task<IEnumerable<AdmissionDetailsDTO>> GetAllAdmissionsDetails()
        {
            var list = _admissionRepository.GetAdmissionsDetails();
            var returnList = _mapper.Map<IEnumerable<Admission>, IEnumerable<DTO.AdmissionDetailsDTO>>(list);
            return returnList;
        }

        public async Task<IEnumerable<AdmissionDetailsDTO>> GetAllAdmissionsSearch(string start, string end)
        {
            var list = _admissionRepository.GetAdmissionsSearch(start, end);
            var returnList = _mapper.Map<IEnumerable<Admission>, IEnumerable<DTO.AdmissionDetailsDTO>>(list);
            return returnList;
        }

        public async Task UpdateAdmission(AdmissionDTO admission)
        {
            var admissionToUpdate = _mapper.Map<DTO.AdmissionDTO, Admission>(admission);
            await _admissionRepository.UpdateAdmission(admissionToUpdate);
        }
    }
}
