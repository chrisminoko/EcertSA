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
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CategoriesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetCategories()
        {
            var companies = _repository.Category.GetAllCategories(trackChanges: false);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var company = _repository.Category.GetCategory(id, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Category with id : {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                return Ok(company);
            }
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Category category)
        {
            if (category==null)
            {
                _logger.LogError("category object sent from client is null.");
                return BadRequest("category object is null");
            }
            _repository.Category.CreateCategory(category);
            _repository.Save();
            return Ok();
            //return CreatedAtRoute("CategoryById", new { id = category.CategoryId }, category);
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _repository.Category.GetCategory(categoryId, trackChanges: false);
            if (category != null)
            {
                _repository.Category.DeleteCategory(category);
                _repository.Save();
                return Ok();
            }
            else
            {
                _logger.LogError("category object sent from client is null.");
                return NoContent();
            };
        }
     }
}
