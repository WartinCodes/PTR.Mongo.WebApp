using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PTR.Mongo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetAllByUserId(int userId)
        {
            var products = _productService.GetAllByUserIdAsync(userId);
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult GetById(int productId)
        {
            var product = _productService.GetByProductId(productId);
            return Ok(product);
        }

        [HttpPost("create")]
        public IActionResult Create(CreateProductRequestDto request)
        {
            var newProduct = _productService.Create(request);
            return Ok(newProduct);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
