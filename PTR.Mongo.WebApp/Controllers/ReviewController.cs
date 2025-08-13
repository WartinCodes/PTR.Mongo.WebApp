using Microsoft.AspNetCore.Mvc;
using PTR.Mongo.WebApp.Entities;
using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Services.Interfaces;

namespace PTR.Mongo.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET api/review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        // GET api/review/search?fieldName=ProductId&fieldValue=123
        [HttpGet("search")]
        public async Task<IActionResult> Search(string fieldName, string fieldValue)
        {
            var reviews = await _reviewService.GetAllAsync(fieldName, fieldValue);
            return Ok(reviews);
        }

        [HttpGet("partialSearch")]
        public async Task<ActionResult<IEnumerable<Review>>> Search([FromQuery] string author)
        {
            if (string.IsNullOrWhiteSpace(author))
                return BadRequest("El parámetro 'author' es requerido.");

            var results = await _reviewService.SearchByAuthorAsync(author);
            return Ok(results);
        }

        // POST api/review
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReviewRequest review)
        {
            await _reviewService.AddAsync(review);
            return Ok();
        }

        // PUT api/review/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Review review)
        {
            var success = await _reviewService.UpdateAsync(review, id);
            if (!success) return NotFound();
            return NoContent();
        }

        // DELETE api/review/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }
    }
}
