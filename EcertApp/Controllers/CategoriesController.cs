using Contracts;
using EcertApp.BLL.Contracts;
using Microsoft.AspNetCore.Mvc;


namespace EcertApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryBll _db;
        private readonly ILoggerManager _logger;
        public CategoriesController(ICategoryBll db,ILoggerManager logger)
        {
            _db = db;
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
        public IActionResult CreateCategory( Models.Category category)
        {
            try
            {
                _db.CreateCategory(category);
                return RedirectToAction("Categories");
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }
        }
        public IActionResult Categories(int page = 1)
        {
            try
            {
                var pagedData = _db.GetCategories(page);
                return View(pagedData);
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }

        }
        public IActionResult GetCategory(int id)
        {
            try
            {
                var results = _db.GetCategory(id);
                ViewBag.Category = results;
                return View();
            }
            catch (System.Exception ex)
            {

                _logger.LogError($"Something went wrong : { ex.Message} ");
                return BadRequest();
            }

        }
        public IActionResult DeleteCategory(int CategoryId)
        {
            try
            {
                _db.DeleteCategory(CategoryId);
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
