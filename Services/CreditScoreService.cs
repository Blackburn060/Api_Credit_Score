using CsvHelper;
using System.Globalization;
using VehicleInsuranceAPI.Models;

namespace VehicleInsuranceAPI.Services
{
    public class CreditScoreService
    {
        private readonly List<InsuranceRecord> _records;
        private static readonly object _lock = new object();

        public CreditScoreService()
        {
            _records = LoadRecordsFromCsv("Car_Insurance_Claim.csv");
        }

        private List<InsuranceRecord> LoadRecordsFromCsv(string filePath)
        {
            lock (_lock)
            {
                using var reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read));
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                return csv.GetRecords<InsuranceRecord>().ToList();
            }
        }

        public double GetCreditScore(CreditScoreRequest request)
        {
            var record = _records.FirstOrDefault(r =>
                string.Equals(r.Age, request.Age, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.Gender, request.Gender, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.YearsLicensed, request.YearsLicensed, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.EducationLevel, request.EducationLevel, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.IncomeLevel, request.IncomeLevel, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.VehicleYear, request.VehicleYear, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.VehicleType, request.VehicleType, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(r.AnnualMileage, request.AnnualMileage, StringComparison.OrdinalIgnoreCase)
            );

            if (record == null || string.IsNullOrWhiteSpace(record.CreditScore))
                return 0;

            if (double.TryParse(record.CreditScore, out double creditScore))
                return creditScore;

            return 0;
        }
    }
}
