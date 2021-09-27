using Microsoft.AspNetCore.Mvc;
using ShopApi.Managers.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _CategoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _CategoryManager = categoryManager;
        }
        // GET: api/<CategorysController>
        [HttpGet]
        public IActionResult Get()
        {
            var categorys = _CategoryManager.GetAll();

            if(categorys == null || categorys.Count < 1)
            {
                return NotFound();
            }

            return Ok(categorys);
        }
    }
}
