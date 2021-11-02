using AutoMapper;
using Project1.Models;
using Project1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            this._patientRepository = patientRepository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<DTO.PatientDTO>> ListAsync()
        {
            var list = await _patientRepository.ListAsync();
            var returnList = _mapper.Map<IEnumerable<Patient>, IEnumerable<DTO.PatientDTO>>(list);
            return returnList;

        }

        public async Task<DTO.PatientDTO> GetPatientById(int id)
        {
            var patient =  await _patientRepository.GetPatientById(id);
            DTO.PatientDTO returnPatient =  _mapper.Map<DTO.PatientDTO>(patient);
            return returnPatient;
        }

        public async Task<DTO.PatientDTO> GetPatientByJMBG(long jmbg)
        {
            var patient =  await _patientRepository.GetPatientByJMBG(jmbg);
            var returnPatient = _mapper.Map<Patient, DTO.PatientDTO>(patient);
            return returnPatient;
        }

        public async Task<DTO.PatientDTO> UpdatePatient(DTO.PatientDTO patient)
        {
            var patientToUpdate = _mapper.Map<DTO.PatientDTO, Patient>(patient);
            var updatedPatient = await _patientRepository.UpdatePatientDetails(patientToUpdate);
            DTO.PatientDTO returnPatient = _mapper.Map<DTO.PatientDTO>(updatedPatient);
            return returnPatient;
        }

        public async Task<DTO.PatientDTO> CreatePatient(DTO.PatientDTO patient)
        {
            var patientToCreate = _mapper.Map<DTO.PatientDTO, Patient>(patient);
            var addedPatient = await _patientRepository.CreatePatient(patientToCreate);
            DTO.PatientDTO returnPatient = _mapper.Map<DTO.PatientDTO>(addedPatient);
            return returnPatient;
        }

        public async Task DeletePatient(int id)
        {
            await _patientRepository.DeletePatient(id);
        }
    }
}
