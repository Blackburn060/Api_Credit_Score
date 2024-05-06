namespace VehicleInsuranceAPI.Models
{
    public class CreditScoreRequest
    {
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? YearsLicensed { get; set; }
        public string? EducationLevel { get; set; }
        public string? IncomeLevel { get; set; }
        public string? VehicleYear { get; set; }
        public string? VehicleType { get; set; }
        public string? AnnualMileage { get; set; }
    }
}
