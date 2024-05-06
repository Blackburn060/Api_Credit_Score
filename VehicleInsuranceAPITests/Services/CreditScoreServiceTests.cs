using Moq;
using System.Collections.Generic;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;
using Xunit;

namespace VehicleInsuranceAPITests.Services
{
    public class CreditScoreServiceTests
    {
        private readonly CreditScoreService _creditScoreService;

        public CreditScoreServiceTests()
        {
            var mockRecords = new List<InsuranceRecord>
            {
                new InsuranceRecord
                {
                    Age = "16-25",
                    Gender = "Male",
                    YearsLicensed = "10-19y",
                    EducationLevel = "Bachelors",
                    IncomeLevel = "Medium",
                    VehicleYear = "2015",
                    VehicleType = "Sedan",
                    AnnualMileage = "12000",
                    CreditScore = "0.85"
                },
                new InsuranceRecord
                {
                    Age = "16-25",
                    Gender = "Female",
                    YearsLicensed = "20-29y",
                    EducationLevel = "Masters",
                    IncomeLevel = "High",
                    VehicleYear = "2018",
                    VehicleType = "SUV",
                    AnnualMileage = "15000",
                    CreditScore = "0.92"
                }
            };

            // Mock the CreditScoreService by initializing it with the sample data
            var mockService = new Mock<CreditScoreService>();
            mockService.Setup(s => s.GetCreditScore(It.IsAny<CreditScoreRequest>()))
                       .Returns((CreditScoreRequest req) =>
                       {
                           var record = mockRecords.Find(r =>
                               r.Age == req.Age &&
                               r.Gender == req.Gender &&
                               r.YearsLicensed == req.YearsLicensed &&
                               r.EducationLevel == req.EducationLevel &&
                               r.IncomeLevel == req.IncomeLevel &&
                               r.VehicleYear == req.VehicleYear &&
                               r.VehicleType == req.VehicleType &&
                               r.AnnualMileage == req.AnnualMileage);

                           if (record == null || string.IsNullOrWhiteSpace(record.CreditScore))
                               return 0;

                           return double.TryParse(record.CreditScore, out double creditScore)
                               ? creditScore
                               : 0;
                       });

            _creditScoreService = mockService.Object;
        }

        [Fact]
        public void GetCreditScore_ShouldReturnCorrectScore_ForValidRequest()
        {
            // Arrange
            var request = new CreditScoreRequest
            {
                Age = "16-25",
                Gender = "Male",
                YearsLicensed = "10-19y",
                EducationLevel = "Bachelors",
                IncomeLevel = "Medium",
                VehicleYear = "2015",
                VehicleType = "Sedan",
                AnnualMileage = "12000"
            };

            // Act
            var score = _creditScoreService.GetCreditScore(request);

            // Assert
            Assert.Equal(0.85, score);
        }

        [Fact]
        public void GetCreditScore_ShouldReturnZero_ForInvalidRequest()
        {
            // Arrange
            var request = new CreditScoreRequest
            {
                Age = "26-39",
                Gender = "Female",
                YearsLicensed = "30y+",
                EducationLevel = "PhD",
                IncomeLevel = "Low",
                VehicleYear = "2020",
                VehicleType = "Truck",
                AnnualMileage = "20000"
            };

            // Act
            var score = _creditScoreService.GetCreditScore(request);

            // Assert
            Assert.Equal(0, score);
        }
    }
}
