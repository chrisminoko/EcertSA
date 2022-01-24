using Contracts;
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
        public IActionResult GetCompany(int id)
        {
            var company = _repository.Category.GetCategory(id, trackChanges: false);
            if (company == null)
            {
                _logger.LogInfo($"Company with id : {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {

                return Ok(company);
            }
        }
    }
}
