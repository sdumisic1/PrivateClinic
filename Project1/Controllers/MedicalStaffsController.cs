using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Services;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalStaffsController : Controller
    {
        private readonly IMedicalStaffService _staffService;

        public MedicalStaffsController(IMedicalStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.MedicalStaffDTO>>> GetStaffs()
        {
            var staffs = await _staffService.ListAsync();
            return Ok(staffs);
        }


        // GET: api/MedicalStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.MedicalStaffDTO>> GetStaff(int id)
        {
            var staff = await _staffService.GetMedicalStaffById(id);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // GET: api/MedicalStaffs/doctors
        [HttpGet("doctors")]
        public async Task<ActionResult<IEnumerable<DTO.MedicalStaffDTO>>> GetAllDoctors()
        {
            var staff = await _staffService.GetAllDoctors();

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }
        // PUT: api/MedicalStaffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, [FromBody] DTO.MedicalStaffDTO staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            DTO.MedicalStaffDTO updatedStaff;

            try
            {
                updatedStaff = await _staffService.UpdateMedicalStaff(staff);

            }
            catch (Exception err)
            {
                throw err;
            }
            return Ok(updatedStaff);
        }

        // POST: api/MedicalStaffs
        [HttpPost]
        public async Task<ActionResult<MedicalStaff>> PostStaff([FromBody] DTO.MedicalStaffDTO staff)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            DTO.MedicalStaffDTO createdStaff;
            try
            {
                createdStaff = await _staffService.CreateMedicalStaff(staff);

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(createdStaff);
        }

        // DELETE: api/MedicalStaffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MedicalStaff>> DeleteStaff(int id)
        {
            try
            {
                await _staffService.DeleteMedicalStaffDTO(id);
            }
            catch (Exception err)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
