using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_Proyect_Jucar.Controllers.Products
{
    public class AutopartController : Controller
    {
        private readonly HttpClient _httpClient;

        // GET: AutopartController
        public AutopartController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7028/api/autoparts/"); // Ajusta la ruta base según tu API..
        }

        // GET: api/autopart
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autoparts = JsonConvert.DeserializeObject<List<AutopartViewModel>>(json);//
                return View(autoparts);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return View(Enumerable.Empty<CategoryViewModel>());
            }
        }

        // GET: api/autopart/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"Details/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autoparts = JsonConvert.DeserializeObject<AutopartViewModel>(json);
                return View(autoparts);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/autopart/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: api/autopart/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutopartViewModel autopart)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(autopart);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create autopart. Please try again.");
                }
            }

            return View(autopart);
        }


        // GET: api/autopart/Edit/5
        [HttpGet("Edit/{Id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"Edit/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autoparts = JsonConvert.DeserializeObject<AutopartViewModel>(json);
                return View(autoparts);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/autopart/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AutopartViewModel autopart)
        {
            if (id != autopart.AutopartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(autopart);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Edit/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update category. Please try again.");
                }
            }

            return View(autopart);
        }

        // GET: api/autopart/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var autopart = JsonConvert.DeserializeObject<AutopartViewModel>(json);
                return View(autopart);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/autopart/Delete/5
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete category. Please try again.");
                return View();
            }
        }
    }
}
