using FizzBuzzAPI.Controllers;
using NUnit.Compatibility;
using NUnit.Framework;
using FizzBuzzAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FizzBuzzAPI.Tests
{
    [TestFixture]
    public class FizzBuzzControllerTests
    {
        private Mock<IFizzBuzzService> _mockFizzBuzzService;
        private FizzBuzzController _controller;

        [SetUp]
        public void Setup()
        {
            _mockFizzBuzzService = new Mock<IFizzBuzzService>();
            _controller = new FizzBuzzController(_mockFizzBuzzService.Object);
        }

        [Test]
        public void GetFizzBuzz_ValidNumber_ReturnsExpectedResult()
        {
            // Arrange
            int input = 15;
            string expected = "FizzBuzz";
            _mockFizzBuzzService.Setup(service => service.GetFizzBuzzResult(input)).Returns(expected);

            // Act
            var result = _controller.GetFizzBuzz(input.ToString()) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(expected, result.Value);
        }
        [Test]
        public void GetFizzBuzz_AlphabeticInput_ReturnsBadRequest()
        {
            // Act
            var result = _controller.GetFizzBuzz("abc") as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Invalid input. Alphabetic characters are not allowed. Please enter a valid number.", result.Value);
        }

        [Test]
        public void GetFizzBuzz_EmptyInput_ReturnsBadRequest()
        {
            // Act
            var result = _controller.GetFizzBuzz("") as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Input cannot be empty. Please enter a valid number.", result.Value);
        }

        [Test]
        public void GetFizzBuzz_NonNumericInput_ReturnsBadRequest()
        {
            // Act
            var result = _controller.GetFizzBuzz("123.45") as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("Invalid input. Please enter a valid number.", result.Value);
        }

        [Test]
        public void GetFizzBuzz_ValidInput_CallsFizzBuzzService()
        {
            // Arrange
            int input = 3;
            _mockFizzBuzzService.Setup(service => service.GetFizzBuzzResult(input)).Returns("Fizz");

            // Act
            var result = _controller.GetFizzBuzz(input.ToString()) as OkObjectResult;

            // Assert
            _mockFizzBuzzService.Verify(service => service.GetFizzBuzzResult(input), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("Fizz", result.Value);
        }
    }
}