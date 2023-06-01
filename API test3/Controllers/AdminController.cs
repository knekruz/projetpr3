using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API_test3.Data;
using API_test3.Models;
using API_test3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_test3.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserService _userService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DataContext context, UserService userService, ILogger<AdminController> logger)
        {
            _context = context;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin([FromBody] Admin admin)
        {
            // Generate a random password
            string randomPassword = _userService.GenerateRandomPassword();
            admin.HashPass = _userService.HashPassword(randomPassword);

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            // Log the generated password
            _logger.LogInformation($"Generated password for {admin.Username}: {randomPassword}");

            return Ok(new { admin, randomPassword });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] AdminDTO request)
        {
            var admin = await _userService.LoginAdmin(request.Username, request.Password);

            if (admin == null)
            {
                return BadRequest(new { message = "Invalid Username or Password" });
            }

            // Generate a JWT token for the admin
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("dzR5cVBTS3VxNVdRbElkNmZFdUJ3S3RlYWU2U3lUVWZNT1h0Mm5WWEdHc1NUZw=="); // replace with your actual secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", admin.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return the user and token
            return Ok(new
            {
                Id = admin.Id,
                Name = admin.Name,
                LastName = admin.LastName,
                Username = admin.Username,
                Token = tokenHandler.WriteToken(token)
            });
        }


        // You can add more methods here for CRUD operations (Get, Put, Delete etc.)
    }


}
