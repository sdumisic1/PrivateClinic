using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project1.Repositories
{
    public class AdmissionRepository : BaseRepository, IAdmissionRepository
    {
        public AdmissionRepository(Project1Context context) : base(context)
        {
        }

        public async Task<Admission> CreateAdmission(Admission admission)
        {
            var newAdmission = await _context.Admission.AddAsync(admission);
            await _context.SaveChangesAsync();
            return newAdmission.Entity;
        }

        public async Task DeleteAdmission(int id)
        {
            var existingAdmission = await _context.Admission.SingleOrDefaultAsync(c => c.AdmissionId == id);

            //if doesn't exist throw exception
            if (existingAdmission == null)
                throw new RepositoryException("Admission with this ID doesn't exist!");

            _context.Admission.Remove(existingAdmission);
            await _context.SaveChangesAsync();
        }

        public async Task<Admission> GetAdmissionById(int id)
        {
            return await _context.Admission.FirstOrDefaultAsync(p => p.AdmissionId == id);
        }
        public async Task<Admission> GetAdmissionDetailsById(int id)
        {
            return await _context.Admission.Include(a => a.Patient).Include(a => a.Report).Include(a => a.Staff).FirstOrDefaultAsync(p => p.AdmissionId == id);
        }

        public async Task<IEnumerable<Admission>> ListAsync()
        {
            return await _context.Admission.ToListAsync();
        }
        public IEnumerable<Admission> GetAdmissionsDetails()
        {
            return _context.Admission.Include(a => a.Patient).Include(a => a.Report).Include(a => a.Staff);
        }
        public IEnumerable<Admission> GetAdmissionsSearch(string startDate, string endDate)
        {
            
            return _context.Admission.Where(s => s.DateAndTime > DateTime.Parse(startDate) & s.DateAndTime < DateTime.Parse(endDate))
                                    .Include(a => a.Patient)
                                    .Include(a => a.Report)
                                    .Include(a => a.Staff);
        }
        public async Task UpdateAdmission(Admission admission)
        {
            //find report
            var existingAdmission = await _context.Admission.SingleOrDefaultAsync(c => c.AdmissionId == admission.AdmissionId);

            //if doesn't exist throw exception
            if (existingAdmission == null)
                throw new RepositoryException("Admission with this ID doesn't exist!");

            existingAdmission.IsEmergency = admission.IsEmergency;
            existingAdmission.PatientId = admission.PatientId;
            existingAdmission.StaffId = admission.StaffId;

            await _context.SaveChangesAsync();
            
        }
    }
}
