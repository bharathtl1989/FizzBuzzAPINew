using FizzBuzzAPI.Factory.Interface;
using FizzBuzzAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzServiceFactory _fizzBuzzServiceFactory;

        public FizzBuzzController(IFizzBuzzServiceFactory fizzBuzzServiceFactory)
        {
            _fizzBuzzServiceFactory = fizzBuzzServiceFactory;
        }
        [HttpPost("GetFizzBuzz")]
        public IActionResult GetFizzBuzz([FromBody] List<string> inputs)
        {
            if (inputs == null || !inputs.Any())
            {
                return BadRequest("Input cannot be empty. Please provide a list of numbers.");
            }

            // Use the factory to create an instance of FizzBuzzService
            var fizzBuzzService = _fizzBuzzServiceFactory.CreateFizzBuzzService();

            var results = fizzBuzzService.GetFizzBuzzResult(inputs);
            return Ok(results);
        }
    }
}
