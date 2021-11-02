using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services
{
    public interface IReportService
    {
        Task<IEnumerable<DTO.ReportDTO>> ListAsync();
        Task<DTO.ReportDTO> GetReportById(int id);
        Task UpdateReport(DTO.ReportDTO report);
        Task<DTO.ReportDTO> CreateReport(DTO.ReportDTO report);
        Task DeleteReport(int id);
    }
}
