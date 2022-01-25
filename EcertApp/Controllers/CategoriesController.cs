using EcertApp.Dto;
using EcertApp.EcertApiHelper.Implementations;
using EcertApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace EcertApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpLogic<Models.Category> _http;
        public CategoriesController(IHttpLogic<Models.Category> http)
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
        public IActionResult CreateCategory(Models.Category category)
        {
            var repose = _http.PostCall(category, "https://localhost:44335/api/Categories");
            return RedirectToAction("Categories");
        }

        public  IActionResult Categories(int page = 1)
        {
            var results =  _http.Get("https://localhost:44335/api/Categories").Result.ToList();
            var pagedData = results.GetPaged(page, 2);
            PagedResult<Models.Category> pagedResult = new()
            {
                CurrentPage = pagedData.CurrentPage,
                PageCount = pagedData.PageCount,
                RowCount = pagedData.RowCount
            };

            ViewBag.Categories = pagedResult;
            foreach (var category in pagedData.Results)
            {
                pagedResult.Results.Add(category);
            }
            return View(pagedData);
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
