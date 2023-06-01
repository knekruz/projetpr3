using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using ApplicationMobile.Models;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace ApplicationMobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "https://pr3api.azurewebsites.net/api";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }


        public async Task<Student> GetStudentByEmail(string email)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/Student/GetByEmail/{email}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to get student.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<Student>(content);

            return student;
        }

        public async Task<string> Login(string email, string password)
        {
            var loginData = new { Email = email, Password = password };
            var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_apiUrl}/Student/login", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Login failed.");
            }

            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
