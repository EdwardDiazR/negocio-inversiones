using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.LoanRequest;
using NegocioInversiones.Models.SolicitudModels;

namespace NegocioInversiones.Controllers
{
    [Route("api/v2/loan-request")]
    [ApiController]
    public class LoanRequestController : ControllerBase
    {
        private readonly ILoanRequestService _loanRequestService;
        public LoanRequestController(ILoanRequestService loanRequestService)
        {
            _loanRequestService = loanRequestService;
        }

        [HttpGet]
        [Route("customer-loan-requests")]
        public ActionResult GetCustomerLoanRequests(int CustomerId)
        {
            try
            {
                List<LoanRequest> loanRequest = _loanRequestService.GetCustomerLoanRequests(CustomerId);
                return Ok(loanRequest);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        [Route("create-loan-request")]
        public ActionResult CreateLoanRequest(CreateLoanRequestDto createLoanRequestDto)
        {
            try
            {
                LoanRequest loanRequest = _loanRequestService.CreateLoanRequest(createLoanRequestDto);
                //TODO: Return the loan request 
                return Ok(loanRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        public void PreApproveRequest()
        {
            //TODO: Approve Loan request and notify the customer of new Loan Offer
            //Ex: Approved Amount, Time, Interest Rate
            //To wait the customer for accept or reject that offer
        }
    }
}
