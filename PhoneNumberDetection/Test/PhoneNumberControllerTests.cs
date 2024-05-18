using Xunit;
using PhoneNumberDetection.Controllers;
using PhoneNumberDetection.Models;
using Microsoft.AspNetCore.Mvc;

namespace PhoneNumberDetection.Tests
{
    public class PhoneNumberControllerTests
    {
        [Fact]
        public void Convert_ValidPhoneNumber_ReturnsValidResult()
        {
            // Arrange
            var controller = new PhoneNumberController();
            var model = new PhoneNumberModel { InputText = "111-111-1111" };

            // Act
            var result = controller.Convert(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var viewModel = result.Model as PhoneNumberModel;
            Assert.NotNull(viewModel);
            Assert.True(string.IsNullOrEmpty(viewModel.ValidationResult)); // Valid phone number should have empty ValidationResult
        }

        [Fact]
        public void Convert_InvalidPhoneNumber_ReturnsError()
        {
            // Arrange
            var controller = new PhoneNumberController();
            var model = new PhoneNumberModel { InputText = "not a phone number" };

            // Act
            var result = controller.Convert(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var viewModel = result.Model as PhoneNumberModel;
            Assert.NotNull(viewModel);
            Assert.False(string.IsNullOrEmpty(viewModel.ValidationResult)); // Invalid phone number should have non-empty ValidationResult
        }


        [Fact]
        public void Convert_ValidPhoneNumber_Words_ReturnsValidResult()
        {
            // Arrange
            var controller = new PhoneNumberController();
            var model = new PhoneNumberModel { InputText = "एक दो तीन चार पांच छह सात eight नौ शुन्य" };

            // Act
            var result = controller.Convert(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var viewModel = result.Model as PhoneNumberModel;
            Assert.NotNull(viewModel);
            Assert.False(string.IsNullOrEmpty(viewModel.ValidationResult)); // Invalid phone number should have non-empty ValidationResult
        }
    }
}
