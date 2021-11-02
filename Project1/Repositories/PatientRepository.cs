using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(Project1Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _context.Patient.ToListAsync();
        }

        public async Task<Patient> GetPatientByJMBG(long jmbg)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.Jmbg == jmbg);
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<Patient> UpdatePatientDetails(Patient patient)
        {
            //find patient
            var existingPatient = await _context.Patient.AsNoTracking().SingleOrDefaultAsync(c => c.PatientId == patient.PatientId);

            //if doesn't exist throw exception
            if (existingPatient == null)
                throw new RepositoryException("Patient with this ID doesn't exist!");

            existingPatient = patient;
            var updatedPatient = _context.Patient.Update(patient).Entity;
            await _context.SaveChangesAsync();
            return updatedPatient;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            var newPatient = await _context.Patient.AddAsync(patient);
            await _context.SaveChangesAsync();
            return newPatient.Entity;
        }

        public async Task DeletePatient(int id)
        {
            //find patient
            var existingPatient = await _context.Patient.SingleOrDefaultAsync(c => c.PatientId == id);

            //if doesn't exist throw exception
            if (existingPatient == null)
                throw new RepositoryException("Patient with this ID doesn't exist!");

            _context.Admission.RemoveRange(_context.Admission.Where(x => x.PatientId == id));
            _context.Patient.Remove(existingPatient);
            _context.SaveChanges();
        }
    }
}
