using ApplicationWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApplicationWeb.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _httpClient.GetFromJsonAsync<List<Person>>("api/Person");
        }

        public async Task AddPerson(Person person)
        {
            await _httpClient.PostAsJsonAsync("api/Person", person);
        }
    }
    
}
