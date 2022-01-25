using EcertApp.Dto;
using EcertApp.EcertApiHelper.Implementations;
using EcertApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcertApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpLogic<Models.Category> _http;
        public HomeController(ILogger<HomeController> logger, IHttpLogic<Models.Category> http)
        {
            _logger = logger;
            _http = http;
        }

        public IActionResult Index()
        {
            var results = _http.Get("https://localhost:44335/api/Categories").Result.ToList();
            ViewBag.Categories = results;
            return View(results);
           
        }
        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
