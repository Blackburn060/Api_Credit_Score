using CsvHelper.Configuration.Attributes;

namespace VehicleInsuranceAPI.Models
{
    public class InsuranceRecord
    {
        [Name("AGE")]
        public string? Age { get; set; }

        [Name("GENDER")]
        public string? Gender { get; set; }

        [Name("DRIVING_EXPERIENCE")]
        public string? YearsLicensed { get; set; }

        [Name("EDUCATION")]
        public string? EducationLevel { get; set; }

        [Name("INCOME")]
        public string? IncomeLevel { get; set; }

        [Name("VEHICLE_YEAR")]
        public string? VehicleYear { get; set; }

        [Name("VEHICLE_TYPE")]
        public string? VehicleType { get; set; }

        [Name("ANNUAL_MILEAGE")]
        public string? AnnualMileage { get; set; }

        [Name("CREDIT_SCORE")]
        public string? CreditScore { get; set; }
    }
}
