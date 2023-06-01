using ApplicationWeb.Services;
using Microsoft.AspNetCore.Mvc;
using ApplicationWeb.Models;
using System.Threading.Tasks;

namespace ApplicationWeb.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApiService _apiService;

        public PersonController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var person = await _apiService.GetAllPersons();
            return View(person);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            await _apiService.AddPerson(person);
            return RedirectToAction("Index");
        }
    }
}
