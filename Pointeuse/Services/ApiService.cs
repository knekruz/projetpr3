using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pointeuse.Models;


namespace Pointeuse.Service
{
    internal class ApiService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://pr3api.azurewebsites.net/"; // replaced with your new API's base URL

        public ApiService()
        {
            _client = new HttpClient();
        }

        public async Task<bool> PostPointageAsync(Pointage pointage)
        {
            string url = _baseUrl + "api/Pointage";
            var json = JsonConvert.SerializeObject(pointage);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

