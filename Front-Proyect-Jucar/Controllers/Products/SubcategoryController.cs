using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Front_Proyect_Jucar.Controllers.Products
{

    public class SubcategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        // GET: CategoryController
        public SubcategoryController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7028/api/subcategories/"); // Ajusta la ruta base según tu API..
        }

        // GET: categories/{categoryId}/subcategories
        public async Task<IActionResult> Index(Guid categoryId)
        {
            var response = await _httpClient.GetAsync($"{categoryId}/subcategories");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var subcategories = JsonConvert.DeserializeObject<List<SubcategoryViewModel>>(json);
                return View(subcategories);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return View(Enumerable.Empty<SubcategoryViewModel>());
            }
        }

        // GET: categories/{categoryId}/subcategories/Details/5
        public async Task<IActionResult> Details(Guid categoryId, Guid id)
        {
            var response = await _httpClient.GetAsync($"{categoryId}/subcategories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var subcategory = JsonConvert.DeserializeObject<SubcategoryViewModel>(json);
                return View(subcategory);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: categories/{categoryId}/subcategories/Create
        public IActionResult Create(Guid categoryId)
        {
            return View();
        }

        // POST: categories/{categoryId}/subcategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid categoryId, SubcategoryViewModel subcategory)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(subcategory);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{categoryId}/subcategories", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { categoryId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create subcategory. Please try again.");
                }
            }

            return View(subcategory);
        }

        // GET: categories/{categoryId}/subcategories/Edit/5
        public async Task<IActionResult> Edit(Guid categoryId, Guid id)
        {
            var response = await _httpClient.GetAsync($"{categoryId}/subcategories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var subcategory = JsonConvert.DeserializeObject<SubcategoryViewModel>(json);
                return View(subcategory);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: categories/{categoryId}/subcategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid categoryId, Guid id, SubcategoryViewModel subcategory)
        {
            if (id != subcategory.SubcategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(subcategory);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{categoryId}/subcategories/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), new { categoryId });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to update subcategory. Please try again.");
                }
            }

            return View(subcategory);
        }

        // GET: categories/{categoryId}/subcategories/Delete/5
        public async Task<IActionResult> Delete(Guid categoryId, Guid id)
        {
            var response = await _httpClient.GetAsync($"{categoryId}/subcategories/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var subcategory = JsonConvert.DeserializeObject<SubcategoryViewModel>(json);
                return View(subcategory);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: categories/{categoryId}/subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid categoryId, Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{categoryId}/subcategories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), new { categoryId });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to delete subcategory. Please try again.");
                return View();
            }
        }
    }
}
