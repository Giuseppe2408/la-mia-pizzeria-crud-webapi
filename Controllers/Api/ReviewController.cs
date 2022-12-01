using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        IReviewRepository reviewRepository;

        public ReviewController(IReviewRepository _reviewRepository)
        {
            reviewRepository = _reviewRepository;
        }
        
        public IActionResult Get()
        {
            List<Review> reviews = reviewRepository.All();

            return Ok(reviews);
        }



        //azione di creazione del commento
        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {


            try
            {
                reviewRepository.Create(review);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }

            return Ok(review);
        }


    }
}
