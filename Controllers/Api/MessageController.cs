using la_mia_pizzeria_static.Data;
using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        DbMessageRepository messageRepository;
        
       

        [HttpPost]
        public IActionResult Create([FromBody] Message message)
        {
            try
            {
                messageRepository.Create(message);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
            
            return Ok(message);
        }
    }
}
