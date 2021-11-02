using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project1.DTO;
using Project1.Models;
using Project1.Repositories;

namespace Project1.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            this._reportRepository = reportRepository;
            this._mapper = mapper;
        }

        public async Task<ReportDTO> CreateReport(ReportDTO report)
        {
            var reportToCreate = _mapper.Map<DTO.ReportDTO, Report>(report);
            var addedReport = await _reportRepository.CreateReport(reportToCreate);
            DTO.ReportDTO returnReport = _mapper.Map<DTO.ReportDTO>(addedReport);
            return returnReport;
        }

        public async Task DeleteReport(int id)
        {
            await _reportRepository.DeleteReport(id);
        }

        public async Task<ReportDTO> GetReportById(int id)
        {
            var report = await _reportRepository.GetReportById(id);
            DTO.ReportDTO returnReport = _mapper.Map<DTO.ReportDTO>(report);
            return returnReport;
        }

        public async Task<IEnumerable<ReportDTO>> ListAsync()
        {
            var list = await _reportRepository.ListAsync();
            var returnList = _mapper.Map<IEnumerable<Report>, IEnumerable<DTO.ReportDTO>>(list);
            return returnList;
        }

        public async Task UpdateReport(ReportDTO report)
        {
            var reportToUpdate = _mapper.Map<DTO.ReportDTO, Report>(report);
            await _reportRepository.UpdateReport(reportToUpdate);
            //DTO.ReportDTO returnReport = _mapper.Map<DTO.ReportDTO>(updatedReport);
            //return returnReport;
        }
    }
}
