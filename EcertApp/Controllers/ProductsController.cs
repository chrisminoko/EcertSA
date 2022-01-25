using Contracts;
using EcertApp.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcertApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductBll _db;
        private readonly ILoggerManager _logger;
        public ProductsController(IProductBll db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Models.Product product)
        {
            try
            {
                _db.CreateProduct(product);
                return RedirectToAction("Products");
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }
        }

        public IActionResult Products(int page = 1)
        {
            try
            {
                var pagedData = _db.GetProducts(page);
                return View(pagedData);
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }

        }
        public IActionResult GetProduct(int id)
        {
            try
            {
                var results = _db.GetProduct(id);
                ViewBag.Products = results;
                return View();
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }

        }
    }
}
