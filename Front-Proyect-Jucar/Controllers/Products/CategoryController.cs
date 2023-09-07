using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_Proyect_Jucar.Controllers.Products
{
    public class CategoryController : Controller
    {
        static HttpClient client = new HttpClient();

        // GET: CategoryController
        public ActionResult Index()
        {
            IEnumerable<CategoryViewModel> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://localhost:7028/api/categories ");
                //HTTP GET
                var responseTask = client.GetAsync("categories");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var contentTask = result.Content.ReadAsStringAsync();
                    contentTask.Wait();
                    var json = contentTask.Result;
                    categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(json); ;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    categories = Enumerable.Empty<CategoryViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
