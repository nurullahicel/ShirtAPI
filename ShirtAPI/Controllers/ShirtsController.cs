using Microsoft.AspNetCore.Mvc;
using ShirtAPI.Data;
using ShirtAPI.Filters;
using ShirtAPI.Filters.ActionFilters;
using ShirtAPI.Filters.ExceptionFilters;
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
            return Ok(ShirtStore.GetShirts());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtStore.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtStore.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.Id }, shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtStore.UpdateShirt(shirt);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtStore.GetShirtById(id);
            ShirtStore.DeleteShirt(id);
            return Ok(shirt);
        }

    }
}
