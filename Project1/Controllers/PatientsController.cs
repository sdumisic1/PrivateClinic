using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Services;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IEnumerable<DTO.PatientDTO>> GetPatients()
        {
            return await _patientService.ListAsync();
        }


        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.PatientDTO>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }


        // GET: api/Patients/jmbg/5
        [HttpGet("jmbg/{jmbg}")]
        public async Task<ActionResult<Patient>> GetPatientByJMBG(long jmbg)
        {
            var patient = await _patientService.GetPatientByJMBG(jmbg);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DTO.PatientDTO>> PutPatient(int id, [FromBody] DTO.PatientDTO patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }
            
            DTO.PatientDTO updatedPatient;
            
            try
            {
                 updatedPatient = await _patientService.UpdatePatient(patient);
               
            }
            catch (Exception err)
            {
                throw err;
            }
            return Ok(updatedPatient);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<DTO.PatientDTO>> PostPatient([FromBody] DTO.PatientDTO patient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            DTO.PatientDTO createdPatient = new DTO.PatientDTO();
            try
            {
                createdPatient = await _patientService.CreatePatient(patient);

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(createdPatient);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult DeletePatient(int id)
        {
            try
            {
                _patientService.DeletePatient(id);
            }
            catch (Exception err)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
