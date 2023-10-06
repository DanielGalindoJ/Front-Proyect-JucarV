using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumoMVC.Controllers
{
    public class RawMaterialsController : Controller
    {
        private readonly HttpClient _httpClient;

        public RawMaterialsController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7028/api/rawMaterials"); // Ajusta la ruta base según tu API.
        }

        // GET: api/rawMaterials
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rawMaterials = JsonConvert.DeserializeObject<List<RawMaterialViewModel>>(json);
                return View(rawMaterials);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return View(Enumerable.Empty<RawMaterialViewModel>());
            }
        }

        // GET: api/rawMaterials/Details/5
        [HttpGet("rawMaterials/Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"Details/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rawMaterial = JsonConvert.DeserializeObject<RawMaterialViewModel>(json);
                return View(rawMaterial);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/rawMaterials/Create
        [HttpGet("rawMaterials/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: api/rawMaterials/Create
        [HttpPost("rawMaterials/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RawMaterialViewModel rawMaterial)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(rawMaterial);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create raw material. Please try again.");
                }
            }

            return View(rawMaterial);
        }

        // GET: api/rawMaterials/Edit/5
        [HttpGet("rawMaterials/Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"Edit/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rawMaterial = JsonConvert.DeserializeObject<RawMaterialViewModel>(json);
                return View(rawMaterial);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/rawMaterials/Edit/5
        [HttpPost("rawMaterials/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RawMaterialViewModel rawMaterial)
        {
            if (id != rawMaterial.RawMaterialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(rawMaterial);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Edit/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update raw material. Please try again.");
                }
            }

            return View(rawMaterial);
        }

        // GET: api/rawMaterials/Delete/5
        [HttpGet("rawMaterials/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var rawMaterial = JsonConvert.DeserializeObject<RawMaterialViewModel>(json);
                return View(rawMaterial);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/rawMaterials/Delete/5
        [HttpPost("rawMaterials/Delete/{id}")]
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
                ModelState.AddModelError(string.Empty, "Failed to delete raw material. Please try again.");
                return View();
            }
        }
    }
}

