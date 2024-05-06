using Microsoft.AspNetCore.Mvc;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;

namespace VehicleInsuranceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditScoreController : ControllerBase
    {
        private readonly CreditScoreService _creditScoreService;

        public CreditScoreController(CreditScoreService creditScoreService)
        {
            _creditScoreService = creditScoreService;
        }

        [HttpPost]
        public ActionResult<CreditScoreResponse> GetCreditScore([FromBody] CreditScoreRequest request)
        {
            var creditScore = _creditScoreService.GetCreditScore(request);

            return Ok(new CreditScoreResponse
            {
                Status = creditScore > 0 ? "Success" : "Not Found",
                CreditScore = creditScore
            });
        }
    }
}
