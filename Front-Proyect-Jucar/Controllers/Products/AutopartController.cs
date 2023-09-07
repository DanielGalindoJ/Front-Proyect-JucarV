using Front_Proyect_Jucar.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front_Proyect_Jucar.Controllers.Products
{
    public class AutopartController : Controller
    {
        static HttpClient client = new HttpClient();


        // GET: CompaniesController
        public ActionResult Index()
        {

            IEnumerable<AutopartViewModel> autoparts = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://localhost:7028/api/autoparts ");
                //HTTP GET
                var responseTask = client.GetAsync("autoparts");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var contentTask = result.Content.ReadAsStringAsync();
                    contentTask.Wait();
                    var json = contentTask.Result;
                    autoparts = JsonConvert.DeserializeObject<List<AutopartViewModel>>(json); ;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    autoparts = Enumerable.Empty<AutopartViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(autoparts);
        }

        // GET: AutopartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AutopartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutopartController/Create
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

        // GET: AutopartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AutopartController/Edit/5
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

        // GET: AutopartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AutopartController/Delete/5
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
