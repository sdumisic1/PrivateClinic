using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project1.Repositories
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        public ReportRepository(Project1Context context) : base(context)
        {
        }

        public async Task<Report> CreateReport(Report report)
        {
            var newReport = await _context.Report.AddAsync(report);
            await _context.SaveChangesAsync();
            return newReport.Entity;
        }

        public async Task DeleteReport(int id)
        {
            //find report
            var existingReport = await _context.Report.SingleOrDefaultAsync(c => c.ReportId == id);

            //if doesn't exist throw exception
            if (existingReport == null)
                throw new RepositoryException("Report with this ID doesn't exist!");

            _context.Report.Remove(existingReport);
            await _context.SaveChangesAsync();

        }

        public async Task<Report> GetReportById(int id)
        {
            return await _context.Report.FirstOrDefaultAsync(p => p.ReportId == id);
        }

        public async Task<IEnumerable<Report>> ListAsync()
        {
            return await _context.Report.ToListAsync();
        }

        public async Task UpdateReport(Report report)
        {
            //find report
            var existingReport = await _context.Report.SingleOrDefaultAsync(c => c.ReportId == report.ReportId);

            //if doesn't exist throw exception
            if (existingReport == null)
                throw new RepositoryException("Report with this ID doesn't exist!");

            existingReport.DateAndTime = report.DateAndTime;
           // var updatedReport = _context.Report.Update(existingReport);
            await _context.SaveChangesAsync();
            //return updatedReport.Entity;
        }
    }
}
