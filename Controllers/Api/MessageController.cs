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

        IDbMessageRepository messageRepository;
        


       public MessageController(IDbMessageRepository _messageRepository)
        {
            messageRepository = _messageRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Message message)
        {

            //if (!ModelState.IsValid)
            //{
            //    return Ok("non valido");
            //}

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
