using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_test3.Data;
using API_test3.Models;

namespace API_test3.Services
{
    public class UserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<Student> Register(Student student, string password)
        {
            // Hash the password
            student.HashPass = HashPassword(password);

            // Save the student
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student> Login(string email, string password)
        {
            // Find the student
            var student = await _context.Students.SingleOrDefaultAsync(u => u.Email == email);

            // Check if student exists and password is correct
            if (student != null && VerifyPassword(password, student.HashPass))
            {
                return student;
            }

            // Authentication failed
            return null;
        }

        public async Task<Admin> LoginAdmin(string username, string password)
        {
            // Find the admin
            var admin = await _context.Admins.SingleOrDefaultAsync(u => u.Username == username);

            // Check if admin exists and password is correct
            if (admin != null && VerifyPassword(password, admin.HashPass))
            {
                return admin;
            }

            // Authentication failed
            return null;
        }


        public string HashPassword(string password)
        {
            // Generate a salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Create the PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            // Hash the password
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine the salt and password
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert to base64 string
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var password = new string(Enumerable.Repeat(chars, 8) // Generate an 8-character password
                .Select(s => s[random.Next(s.Length)])
                .ToArray());

            return password;
        }

        public bool VerifyPassword(string enteredPassword, string savedPasswordHash)
        {
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            /* Compute the hash on the password the student entered */
            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
