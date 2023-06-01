using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationMobile.Models;
using Newtonsoft.Json;

namespace ApplicationMobile.Services
{
    public class UserService
    {
        private const string StudentKey = "student";
        private const string TokenKey = "token";
        private const string EmailKey = "email";

        public async Task SetStudentAsync(Student student)
        {
            await SecureStorage.SetAsync(StudentKey, JsonConvert.SerializeObject(student));
        }

        public async Task<Student> GetStudentAsync()
        {
            var studentJson = await SecureStorage.GetAsync(StudentKey);
            return studentJson == null ? null : JsonConvert.DeserializeObject<Student>(studentJson);
        }

        public async Task SetTokenAsync(string token)
        {
            await SecureStorage.SetAsync(TokenKey, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync(TokenKey);
        }

        public async Task SetEmailAsync(string email)
        {
            await SecureStorage.SetAsync(EmailKey, email);
        }

        public async Task<string> GetEmailAsync()
        {
            return await SecureStorage.GetAsync(EmailKey);
        }
    }
}
