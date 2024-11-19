using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seller.Api.Models;
using Seller.Api.Repository.IRepository;

namespace Seller.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> ReviewById(int id)
        {
            var response = new ResponseDto()
            {
                IsSucceeded = true,
                 Result = await _reviewRepository.getReviewById(id),
                 message="id based review filtering done"
            };
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDto>> GetReviewAll()
        {
            var response = new ResponseDto()
            {
                IsSucceeded = true,
                Result = await _reviewRepository.getAllReview(),
                message = "All reviews fetched"
            };
            return Ok(response);
        }
        [HttpGet("shop")]
        public async Task<ActionResult<ResponseDto>> ReviewByShop(int shopId )
        {
            var response = new ResponseDto()
            {
                IsSucceeded = true,
                Result = await _reviewRepository.getReviewByShop(shopId),
                message = "shop based review filtering done"
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddReview(Review review)
        {
            var response = new ResponseDto()
            {
                IsSucceeded = true,
                Result = await _reviewRepository.postReview(review),
                message = "new review posted",
            };
            return Ok(response);
        }

    }
}
