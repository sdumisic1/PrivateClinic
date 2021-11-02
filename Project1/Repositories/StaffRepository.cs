using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repositories
{
    public class StaffRepository : BaseRepository, IStaffRepository
    {
        public StaffRepository(Project1Context context) : base(context)
        {
        }

        public async Task<MedicalStaff> CreateStaff(MedicalStaff staff)
        {
            var newStaff = await _context.MedicalStaff.AddAsync(staff);
            await _context.SaveChangesAsync();
            return newStaff.Entity;
        }

        public async Task DeleteStaff(int id)
        {
            //find staff
            var existingStaff = await _context.MedicalStaff.SingleOrDefaultAsync(c => c.StaffId == id);

            //if doesn't exist throw exception
            if (existingStaff == null)
                throw new RepositoryException("Staff with this ID doesn't exist!");

            _context.MedicalStaff.RemoveRange(_context.MedicalStaff.Where(x => x.StaffId == id));
            _context.MedicalStaff.Remove(existingStaff);
            await _context.SaveChangesAsync();
        }

        public async Task<MedicalStaff> GetStaffByCode(string code)
        {
            return await _context.MedicalStaff.FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<MedicalStaff> GetStaffById(int id)
        {
            return await _context.MedicalStaff.FirstOrDefaultAsync(p => p.StaffId == id);
        }

        public async Task<IEnumerable<MedicalStaff>> ListAsync()
        {
            return await _context.MedicalStaff.ToListAsync();
        }
        public async Task<IEnumerable<MedicalStaff>> GetAllDoctors()
        {
            return  await _context.MedicalStaff.Where(s => s.Title == "Doctor").ToListAsync();
        }

        public async Task<MedicalStaff> UpdateStaffDetails(MedicalStaff staff)
        {
            //find staff
            var existingStaff = await _context.MedicalStaff.SingleOrDefaultAsync(c => c.StaffId == staff.StaffId);

            //if doesn't exist throw exception
            if (existingStaff == null)
                throw new RepositoryException("Staff with this ID doesn't exist!");

            existingStaff = staff;
            var updatedPatient = _context.MedicalStaff.Update(existingStaff).Entity;
            await _context.SaveChangesAsync();
            return updatedPatient;
        }
    }
}
