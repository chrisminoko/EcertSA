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

        public  IActionResult Categories()
        {
            var results =  _http.Get("https://localhost:44335/api/Categories").ToList();
            return View(results);
        
        }
    }
}
