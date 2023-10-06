using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Front_Proyect_Jucar.Controllers.Products
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        // GET: CategoryController
        public CategoryController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7292/api/categories/"); // Ajusta la ruta base según tu API..
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json);//
                return View(categories);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return View(Enumerable.Empty<CategoryViewModel>());
            }
        }

        // GET: api/categories/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync($"Details/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryViewModel>(json);
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/categories/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: api/categories/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(category);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Failed to create category. Please try again.");
                }
            }

            return View(category);
        }


        // GET: api/categories/Edit/5
        [HttpGet("Edit/{Id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"Edit/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryViewModel>(json);
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/categories/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CategoryViewModel category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(category);
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

            return View(category);
        }

        // GET: api/categories/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryViewModel>(json);
                return View(category);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/categories/Delete/5
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
