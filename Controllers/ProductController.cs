using Microsoft.AspNetCore.Mvc;
using ProductApi.model;

namespace ProductApi.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
    {
        new Product
        {
            id=1,
            title="Inyange",
            description="flavoured milk",
            cost=3000
        },
        new Product
        {
            id=2,
            title="x-product",
            description="flavoured milk",
            cost=3000
        },

        new Product
        {
            id=3,
            title="Ikiryo",
            description="flavoured milk",
            cost=3000
        },

    };

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProduct()
        {
            return Ok(_products);
        }


        [HttpPost]
        public async Task<ActionResult<List<Product>>> createProduct(Product product)
        {
            _products.Add(product);
            return Ok(_products);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> updateProduct(Product product)
        {
            var _prod = _products.Find(p => p.id == product.id);
            if (_prod == null)
            {
                return BadRequest("Product not found!");
            }

            _prod.title = product.title;
            _prod.description = product.description;
            _prod.cost = product.cost;

            return Ok(_prod);
        }
    }
}
