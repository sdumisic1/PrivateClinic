using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Models;
using Project1.Services;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsController : Controller
    {
        private readonly IAdmissionService _admissionService;

        public AdmissionsController(IAdmissionService admissionService)
        {
            _admissionService = admissionService;
        }

        // GET: Admissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.AdmissionDTO>>> GetAdmissions()
        {
            var admissions = await _admissionService.ListAsync();
            return Ok(admissions);
        }

        // GET: Admissions/details
        [HttpGet("details")]
        public async Task<ActionResult<IEnumerable<DTO.AdmissionDetailsDTO>>> GetAdmissionsDetails()
        {
            var admissions = await _admissionService.GetAllAdmissionsDetails();
            return Ok(admissions);
        }

        // GET: Admissions/?startDate=...&endDate=...
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<DTO.AdmissionDetailsDTO>>> GetAdmissionsSearch(string startDate, string endDate)
        {
            var admissions = await _admissionService.GetAllAdmissionsSearch(startDate, endDate);
            return Ok(admissions);
        }

        // GET: Admissions/Details/5
        [HttpGet("details/{id}")]
        public async Task<ActionResult<DTO.AdmissionDetailsDTO>> GetAdmissionDetailsById(int id)
        {
            var admissionDetails = await _admissionService.GetAdmissionDetailsById(id);

            if (admissionDetails == null)
            {
                return NotFound();
            }

            return Ok(admissionDetails);
        }

        // PUT: api/Admissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmissions(int id, [FromBody] DTO.AdmissionDTO admission)
        {
            if (id != admission.AdmissionId)
            {
                return BadRequest();
            }

            try
            {
                 await _admissionService.UpdateAdmission(admission);

            }
            catch (Exception err)
            {
                throw err;
            }
            return Ok();
        }

        // POST: api/Admissions
        [HttpPost]
        public async Task<ActionResult<DTO.AdmissionDTO>> PostAdmission([FromBody] DTO.AdmissionDTO admission)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            DTO.AdmissionDTO createdAdmission;
            try
            {
                createdAdmission = await _admissionService.CreateAdmission(admission);

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(createdAdmission);
        }

        // DELETE: api/Admissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalStaff>> DeleteAdmission(int id)
        {
            try
            {
                await _admissionService.DeleteAdmission(id);
            }
            catch (Exception err)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Admissions/createAll
        [HttpPost("createAll")]
        public async Task<ActionResult> PostAdmissionAll([FromBody] DTO.AdmissionToCreateDTO admission)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                await _admissionService.CreateAdmissionAndReport(admission);

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok();
        }



    }
}
