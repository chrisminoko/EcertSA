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
                return RedirectToAction("Categories");
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }
        }
    }
}
