using EcertApp.Dto;
using EcertApp.EcertApiHelper.Implementations;
using EcertApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Linq;


namespace EcertApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IHttpLogic<Models.Category> _http;
        private readonly IOptions<ApiUrl> _appSettings;
        public CategoriesController(IHttpLogic<Models.Category> http, IOptions<ApiUrl> app)
        {
            _http = http;
            _appSettings = app;
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
            var baseurl = _appSettings.Value.BaseUrl + "Categories";
            var reponse = _http.PostCall(category, baseurl);
            return RedirectToAction("Categories");
        }

        public  IActionResult Categories(int page = 1)
        {
            var baseurl = _appSettings.Value.BaseUrl+ "Categories";
            var results =  _http.Get(baseurl).Result.ToList();
            var pagedData = results.GetPaged(page, 10);
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
            var baseurl = _appSettings.Value.BaseUrl + "Categories/";
            var results = _http.GetbyId(id, baseurl).Result;
            ViewBag.Category = results;
            return View();
        }

        public IActionResult DeleteCategory(int id)
        {
            var baseurl = _appSettings.Value.BaseUrl + "Categories/";
            var results = _http.GetbyId(id, baseurl).Result;
            ViewBag.Category = results;
            return RedirectToAction("Categories");
        }
    }
}
