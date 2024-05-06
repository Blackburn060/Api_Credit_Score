using Microsoft.AspNetCore.Mvc;
using Moq;
using VehicleInsuranceAPI.Controllers;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;
using Xunit;

namespace VehicleInsuranceAPITests.Controllers
{
    public class CreditScoreControllerTests
    {
        [Fact]
        public void GetCreditScore_ExistingRecord_ReturnsSuccess()
        {
            // Arrange
            var mockService = new Mock<CreditScoreService>(MockBehavior.Strict);
            var request = new CreditScoreRequest
            {
                Age = "20",
                Gender = "Male",
                YearsLicensed = "10-19y",
                EducationLevel = "Bachelors",
                IncomeLevel = "Medium",
                VehicleYear = "2015",
                VehicleType = "Sedan",
                AnnualMileage = "12000"
            };
            mockService.Setup(x => x.GetCreditScore(request)).Returns(0.8);

            var controller = new CreditScoreController(mockService.Object);

            // Act
            var result = controller.GetCreditScore(request) as OkObjectResult;
            var response = result?.Value as CreditScoreResponse;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("Success", response.Status);
            Assert.Equal(80, response.CreditScore);
        }

        [Fact]
        public void GetCreditScore_NonExistingRecord_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<CreditScoreService>(MockBehavior.Strict);
            var request = new CreditScoreRequest
            {
                Age = "40",
                Gender = "Non-binary",
                YearsLicensed = "10-19y",
                EducationLevel = "High School",
                IncomeLevel = "Low",
                VehicleYear = "2000",
                VehicleType = "Convertible",
                AnnualMileage = "5000"
            };
            mockService.Setup(x => x.GetCreditScore(request)).Returns(0);

            var controller = new CreditScoreController(mockService.Object);

            // Act
            var result = controller.GetCreditScore(request) as OkObjectResult;
            var response = result?.Value as CreditScoreResponse;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(response);
            Assert.Equal("Not Found", response.Status);
            Assert.Equal(0, response.CreditScore);
        }
    }
}
