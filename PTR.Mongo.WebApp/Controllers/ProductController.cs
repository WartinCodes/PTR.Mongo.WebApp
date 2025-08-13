using Microsoft.AspNetCore.Mvc;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace PTR.Mongo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService, IReviewService reviewService) : ControllerBase
    {
        private readonly IProductService _productService = productService;
        private readonly IReviewService _reviewService = reviewService;

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

        [HttpGet("{productId}/with-reviews")]
        public async Task<IActionResult> GetWithReviews(int productId)
        {
            var productTask = _productService.GetByProductId(productId);
            var reviewsTask = _reviewService.GetAllAsync(nameof(productId), productId.ToString());

            await Task.WhenAll(productTask, reviewsTask);

            var product = await productTask;
            if (product is null)
                return NotFound($"El producto {productId} no existe.");

            var reviews = await reviewsTask;

            var response = new
            {
                product,
                reviews = reviews.Select(r => new
                {
                    id = r.Id.ToString(),
                    authorName = r.AuthorName,
                    comment = r.Comment,
                    rating = r.Rating,
                    createdAt = r.CreatedAt
                })
            };

            return Ok(response);
        }
    }
}
