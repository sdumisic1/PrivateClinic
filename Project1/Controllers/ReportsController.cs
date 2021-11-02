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
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }


        // GET: api/Reports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            var reports = await _reportService.ListAsync();
            return Ok(reports);
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(int id)
        {
            var report = await _reportService.GetReportById(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, [FromBody] DTO.ReportDTO report)
        {
            if (id != report.ReportId)
            {
                return BadRequest();
            }

            try
            {
                 await _reportService.UpdateReport(report);

            }
            catch (Exception err)
            {
                throw err;
            }
            return Ok();
        }

        // POST: api/Reports
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport([FromBody] DTO.ReportDTO report)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            DTO.ReportDTO createdReport;
            try
            {
                createdReport = await _reportService.CreateReport(report);

            }
            catch (Exception err)
            {
                throw err;
            }

            return Ok(createdReport);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Report>> DeleteReport(int id)
        {
            try
            {
                await _reportService.DeleteReport(id);
            }
            catch (Exception err)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
