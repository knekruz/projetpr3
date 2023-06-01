using Microsoft.AspNetCore.Mvc;
using API_test3.Data;
using API_test3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_test3.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_test3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserService _userService;
        private readonly ILogger<StudentController> _logger;

        public StudentController(DataContext context, UserService userService, ILogger<StudentController> logger)
        {
            _context = context;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] Student student)
        {
            // Generate a random password
            string randomPassword = _userService.GenerateRandomPassword();
            student.HashPass = _userService.HashPassword(randomPassword);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            // Log the generated password
            _logger.LogInformation($"Generated password for {student.Email}: {randomPassword}");

            return Ok(new { student, randomPassword });
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _context.Students.Select(s => new
            {
                s.Id,
                s.Name,
                s.LastName,
                s.BirthDate,
                s.Email,
                s.Phone,
                CycleId = s.Cycle.Id,
                CycleName = s.Cycle.Name,
                CycleSectionNumber = s.Cycle.SectionNumber
            }).ToListAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students
                .Where(s => s.Id == id)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.LastName,
                    s.BirthDate,
                    s.Email,
                    s.Phone,
                    CycleId = s.Cycle.Id,
                    CycleName = s.Cycle.Name,
                    CycleSectionNumber = s.Cycle.SectionNumber
                })
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound("Student Not Found");
            }

            return Ok(student);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<Student>> GetStudentByEmail(string email)
        {
            var student = await _context.Students
                .Where(s => s.Email == email)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.LastName,
                    s.BirthDate,
                    s.Email,
                    s.Phone,
                    CycleId = s.Cycle.Id,
                    CycleName = s.Cycle.Name,
                    CycleSectionNumber = s.Cycle.SectionNumber
                })
                .SingleOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("GetByCycleId/{cycleId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByCycleId(int cycleId)
        {
            var students = await _context.Students
                .Where(s => s.Cycle.Id == cycleId)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.LastName,
                    s.BirthDate,
                    s.Email,
                    s.Phone,
                    CycleId = s.Cycle.Id,
                    CycleName = s.Cycle.Name,
                    CycleSectionNumber = s.Cycle.SectionNumber
                })
                .ToListAsync();

            // No need to return NotFound if no students are found, just return an empty list
            // if (students == null || !students.Any())
            // {
            //     return NotFound();
            // }

            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            // Update the student's details
            existingStudent.Name = student.Name;
            existingStudent.LastName = student.LastName;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Email = student.Email;
            existingStudent.Phone = student.Phone;
            existingStudent.CycleId = student.CycleId;

            await _context.SaveChangesAsync();

            return NoContent();  // return 204 response (request has succeeded but doesn't need to return an entity)
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] StudentDTO request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (student == null)
            {
                return BadRequest(new { message = "Invalid Email" });
            }

            if (!_userService.VerifyPassword(request.Password, student.HashPass))
            {
                return BadRequest(new { message = "Invalid Password" });
            }

            // Generate a JWT token for the student
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dzR5cVBTS3VxNVdRbElkNmZFdUJ3S3RlYWU2U3lUVWZNT1h0Mm5WWEdHc1NUZw=="); // replace with your actual secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", student.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the user and token
            return Ok(new
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Email = student.Email,
                Token = tokenHandler.WriteToken(token)
            });
        }
    }

}
