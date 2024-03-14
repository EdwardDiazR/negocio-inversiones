using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NegocioInversiones.Controllers
{
    [Route("api/v1/fraud-check")]
    [ApiController]
    public class FraudController : ControllerBase
    {
        public FraudController() { }

        [HttpGet("{CustomerId}")]
        public ActionResult<bool> IsFraudster(string CustomerId)
        {
            try
            {
                bool isFraudulentCustomer = false;
                return Ok(isFraudulentCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
