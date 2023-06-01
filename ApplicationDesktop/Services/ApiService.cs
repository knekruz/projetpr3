using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApplicationDesktop.Models;
using Newtonsoft.Json;

namespace ApplicationDesktop.Services
{
    internal class ApiService
    {
        private readonly HttpClient _httpClient;
        private string baseUrl = "https://pr3api.azurewebsites.net/api/"; // replace with your API's base URL

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<LoginResponse> LoginAdminAsync(AdminDTO admin)
        {
            var json = JsonConvert.SerializeObject(admin);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(baseUrl + "Admin/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseString);
                return loginResponse;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<List<Cycle>> GetAllCyclesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "Cycle");

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var cycles = JsonConvert.DeserializeObject<List<Cycle>>(responseString);
                return cycles;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<Cycle> AddCycleAsync(Cycle cycle)
        {
            try
            {
                var json = JsonConvert.SerializeObject(cycle);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(baseUrl + "Cycle", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var addedCycle = JsonConvert.DeserializeObject<Cycle>(responseString);
                    return addedCycle;
                }
                else
                {
                    Console.WriteLine($"Error in API Call: {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in AddCycleAsync: {e.Message}");
                return null;
            }
        }
        public async Task UpdateCycleAsync(int id, Cycle updatedCycle)
        {
            var json = JsonConvert.SerializeObject(updatedCycle);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(baseUrl + "Cycle/" + id, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> DeleteCycleAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(baseUrl + "Cycle/" + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Error in API Call: {response.ReasonPhrase}");
                return false;
            }
        }

        public async Task<List<Student>> GetStudentsByCycleIdAsync(int cycleId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(baseUrl + "Student/GetByCycleId/" + cycleId);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<Student>>(responseString);
                return students;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<StudentResponse> AddStudentAsync(Student student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(baseUrl + "Student", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    var addedStudentResponse = JsonConvert.DeserializeObject<StudentResponse>(responseString);
                    return addedStudentResponse;
                }
                else
                {
                    Console.WriteLine($"Error in API Call: {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in AddStudentAsync: {e.Message}");
                return null;
            }
        }

        public async Task UpdateStudentAsync(int id, Student updatedStudent)
        {
            var json = JsonConvert.SerializeObject(updatedStudent);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(baseUrl + "Student/" + id, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(baseUrl + "Student/" + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Error in API Call: {response.ReasonPhrase}");
                return false;
            }
        }



    }
}
