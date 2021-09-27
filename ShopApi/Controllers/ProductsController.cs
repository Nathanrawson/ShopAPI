using Microsoft.AspNetCore.Mvc;
using ShopApi.DatabaseLayer;
using ShopApi.DatabaseLayer.Interfaces;
using ShopApi.Managers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsManager _productsManager;
        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _productsManager.GetAll();

            if(products == null || products.Products.Count < 1)
            {
                return NotFound();
            }

            return Ok(products.Products);
        }

        // GET api/<ValuesController>/5
        [HttpGet("category")]
        public IActionResult GetByCategory(int categoryId)
        {
            var products = _productsManager.GetByCategoryId(categoryId);

            if (products == null || products.Products.Count < 1)
            {
                return NotFound();
            }

            return Ok(products.Products);;
        }
    }
}
