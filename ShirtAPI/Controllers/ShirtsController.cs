using Microsoft.AspNetCore.Mvc;
using ShirtAPI.Data;
using ShirtAPI.Filters;
using ShirtAPI.Models;

namespace ShirtAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]

        public IActionResult GetShirts()
        {
            return Ok("reading all shirts");
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtStore.GetShirtById(id));
        }
      
        [HttpPost]
        public IActionResult CreateShirt([FromBody]Shirt shirt)
        {
            return Ok("dsa");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"updating shirt :{id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"deleting shirt :{id}");
        }

    }
}
