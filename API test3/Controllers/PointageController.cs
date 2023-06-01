using API_test3.Models;
using API_test3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_test3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointageController : ControllerBase
    {
        private readonly DataContext _context;  // Replace YourContext with the name of your DbContext
        private readonly ILogger<PointageController> _logger;

        public PointageController(DataContext context, ILogger<PointageController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: api/Pointages
        [HttpPost]
        public async Task<ActionResult<Pointage>> PostPointage([FromBody] Pointage pointage)
        {
            _context.Pointages.Add(pointage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPointage", new { id = pointage.Id }, pointage);
        }

        [HttpGet]
        public async Task<ActionResult<List<Pointage>>> GetAllPointages()
        {
            return Ok(await _context.Pointages.ToListAsync());
        }

        // GET: api/Pointages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pointage>> GetPointage(int id)
        {
            var pointage = await _context.Pointages.FindAsync(id);

            if (pointage == null)
            {
                return NotFound();
            }

            return pointage;
        }
        [HttpGet("GetByStudentId/{studentId}")]
        public async Task<ActionResult<IEnumerable<Pointage>>> GetPointagesByStudentId(int studentId)
        {
            var students = await _context.Pointages
                .Where(s => s.StudentId == studentId)
                .Select(s => new
                {
                    s.Id,
                    s.TimestampPointage
                })
                .ToListAsync();

            // No need to return NotFound if no students are found, just return an empty list
            // if (students == null || !students.Any())
            // {
            //     return NotFound();
            // }

            return Ok(students);
        }
    }
  
}
