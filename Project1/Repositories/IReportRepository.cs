using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<Report> GetReportById(int id);
        Task UpdateReport(Report report);
        Task<Report> CreateReport(Report report);
        Task DeleteReport(int id);
    }
}
