using FizzBuzzAPI.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using FizzBuzzAPI.Services.Interface;
using FizzBuzzAPI.Factory.Interface;

namespace FizzBuzzAPI.Tests
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzServiceFactory> _mockFizzBuzzServiceFactory;
        private Mock<IFizzBuzzService> _mockFizzBuzzService;
        private FizzBuzzController _controller;

        [SetUp]
        public void Setup()
        {
            _mockFizzBuzzService = new Mock<IFizzBuzzService>();
            _mockFizzBuzzServiceFactory = new Mock<IFizzBuzzServiceFactory>();

            // Setup the factory to return the mock service
            _mockFizzBuzzServiceFactory.Setup(factory => factory.CreateFizzBuzzService())
                                       .Returns(_mockFizzBuzzService.Object);

            _controller = new FizzBuzzController(_mockFizzBuzzServiceFactory.Object);
        }


        [Test]
        public void GetFizzBuzz_ValidList_ReturnsExpectedResults()
        {
            // Arrange
            var inputs = new List<string> { "3", "5", "15", "7" };
            var expected = new List<string> { "Fizz", "Buzz", "FizzBuzz", "Divided 7 by 3\nDivided 7 by 5" };

            _mockFizzBuzzService.Setup(service => service.GetFizzBuzzResult(inputs)).Returns(expected);

            // Act
            var result = _controller.GetFizzBuzz(inputs) as OkObjectResult;

            // Assert
            Assert.Equals(200, result.StatusCode);
        }
        [Test]
        public void GetFizzBuzz_EmptyList_ReturnsBadRequest()
        {
            // Arrange
            var inputs = new List<string>();

            // Act
            var result = _controller.GetFizzBuzz(inputs) as BadRequestObjectResult;

            // Assert
            Assert.Equals(400, result.StatusCode);
            Assert.Equals("Input cannot be empty. Please provide a list of numbers.", result.Value);
        }
        [Test]
        public void GetFizzBuzz_ListWithInvalidEntries_ReturnsExpectedResults()
        {
            // Arrange
            var inputs = new List<string> { "3", "abc", "15", "" };
            var expected = new List<string> { "Fizz", "Invalid input", "FizzBuzz", "Invalid input" };

            _mockFizzBuzzService.Setup(service => service.GetFizzBuzzResult(inputs)).Returns(expected);

            // Act
            var result = _controller.GetFizzBuzz(inputs) as OkObjectResult;

            // Assert
            Assert.Equals(200, result.StatusCode);
            Assert.Equals(expected, result.Value);
        }
        [Test]
        public void GetFizzBuzz_NumberNotDivisibleBy3Or5_ReturnsDividedByMessages()
        {
            // Arrange
            var inputs = new List<string> { "7" };
            var expected = new List<string> { "Divided 7 by 3\nDivided 7 by 5" };

            _mockFizzBuzzService.Setup(service => service.GetFizzBuzzResult(inputs)).Returns(expected);

            // Act
            var result = _controller.GetFizzBuzz(inputs) as OkObjectResult;

            // Assert
            Assert.Equals(200, result.StatusCode);
            Assert.Equals(expected, result.Value);
        }

    }
}