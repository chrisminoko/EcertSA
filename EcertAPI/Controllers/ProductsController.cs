using Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ProductsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _repository.Product.GetAllProducts(trackChanges: false);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var products = _repository.Product.GetProduct(id, trackChanges: false);
            if (products == null)
            {
                _logger.LogInfo($"Product with id : {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                _logger.LogError("Product object sent from client is null.");
                return BadRequest("Product object is null");
            }
            _repository.Product.CreateProduct(product);
            _repository.Save();
            return Ok();
          
        }

        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            var product = _repository.Product.GetProduct(ProductId, trackChanges: false);
            if (product != null)
            {
                _repository.Product.DeleteProduct(product);
                _repository.Save();
                return Ok();
            }
            else
            {
                _logger.LogError("Product object sent from client is null.");
                return NoContent();
            };
        }
    }
}
