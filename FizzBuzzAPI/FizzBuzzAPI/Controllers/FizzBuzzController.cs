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
        [HttpPost("GetFizzBuzz")]
        public IActionResult GetFizzBuzz([FromBody] List<string> inputs)
        {
            if (inputs == null || !inputs.Any())
            {
                return BadRequest("Input cannot be empty.");
            }

            var results = _fizzBuzzService.GetFizzBuzzResult(inputs);
            return Ok(results);
        }
    }
}
