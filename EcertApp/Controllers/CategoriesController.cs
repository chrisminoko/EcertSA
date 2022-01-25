using EcertApp.Dto;
using EcertApp.EcertApiHelper.Implementations;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace EcertApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpLogic<Category> _http;
        public CategoriesController(IHttpLogic<Category> http)
        {
            _http = http;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCategory() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            var repose = _http.PostCall(category, "https://localhost:44335/api/Categories");
            return RedirectToAction("Categories");
        }

        public  IActionResult Categories()
        {
            var results =  _http.Get("https://localhost:44335/api/Categories").Result.ToList();
            ViewBag.Categories = results;
            return View(results);
        }

        public IActionResult GetCategory(int id) 
        {
            var results = _http.GetbyId(id,"https://localhost:44335/api/Categories/").Result;
            ViewBag.Category = results;
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var results = _http.GetbyId(id, "https://localhost:44335/api/Categories/").Result;
            ViewBag.Category = results;
            return RedirectToAction("Categories");
        }
    }
}
