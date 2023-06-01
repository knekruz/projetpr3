using Microsoft.AspNetCore.Mvc;
using API_test3.Data;
using API_test3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace API_test3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CycleController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<CycleController> _logger;

        public CycleController(DataContext context, ILogger<CycleController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddCycle([FromBody] Cycle cycle)
        {
            _context.Cycles.Add(cycle);
            await _context.SaveChangesAsync();

            return Ok(cycle);
        }

        [HttpGet]
        public async Task<ActionResult<List<Cycle>>> GetAllCycles()
        {
            return Ok(await _context.Cycles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cycle>> GetCycle(int id)
        {
            var cycle = await _context.Cycles.FindAsync(id);
            if (cycle == null)
            {
                return NotFound("Cycle Not Found");
            }
            return Ok(cycle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCycle(int id, Cycle cycle)
        {
            Cycle existingCycle = await _context.Cycles.FindAsync(id);

            if (existingCycle == null)
            {
                return NotFound("Cycle not found");
            }

            
            // Update the cycle's details
            existingCycle.SectionNumber = cycle.SectionNumber;
            existingCycle.Name = cycle.Name;
            existingCycle.StartDate = cycle.StartDate;
            existingCycle.EndDate = cycle.EndDate;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCycle(int id)
        {
            Cycle existingCycle = await _context.Cycles.FindAsync(id);

            if (existingCycle == null)
            {
                return NotFound("Cycle not found");
            }

            _context.Cycles.Remove(existingCycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
