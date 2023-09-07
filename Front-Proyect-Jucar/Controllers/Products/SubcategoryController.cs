using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_Proyect_Jucar.Controllers.Products
{

    public class SubcategoryController : Controller
    {
        static HttpClient client = new HttpClient();

        // GET: SubcategoryController
        public ActionResult Index()
        {
            IEnumerable<SubcategoryViewModel> subcategories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7028/api/subcategories  ");
                //HTTP GET
                var responseTask = client.GetAsync("subcategories");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var contentTask = result.Content.ReadAsStringAsync();
                    contentTask.Wait();
                    var json = contentTask.Result;
                    subcategories = JsonConvert.DeserializeObject<List<SubcategoryViewModel>>(json); ;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    subcategories = Enumerable.Empty<SubcategoryViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(subcategories);
        }

        // GET: SubcategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubcategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubcategoryController/Create
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

        // GET: SubcategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Edit/5
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

        // GET: SubcategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Delete/5
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
