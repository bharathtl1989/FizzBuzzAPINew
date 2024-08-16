using FizzBuzzAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        [HttpGet("{input}")]
        public IActionResult GetFizzBuzz(string input)
        {
            // Check if the input contains any alphabetic characters
            if (string.IsNullOrWhiteSpace(input))
            {
                return BadRequest("Invalid input.");
            }
            if (input.Any(char.IsLetter))
            {
                return BadRequest("Invalid input.");
            }

            // Check if the input can be parsed as an integer 
            if (!int.TryParse(input, out int number))
            {
                return BadRequest("Invalid input.");
            }

            var result = _fizzBuzzService.GetFizzBuzzResult(number);
            return Ok(result);
        }
    }
}
