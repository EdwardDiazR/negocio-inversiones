using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.LoanModel;
using NegocioInversiones.Models.LoanModel.Dto;

namespace NegocioInversiones.Controllers
{
    [Route("api/v2/loan")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private ILoanService _loanService;
        public LoanController(ILoanService loanService)
        { _loanService = loanService; }

        [HttpPost]
        [Route("create-loan")]
        public ActionResult CreateLoan(CreateLoanDto createLoanDto)
        {
            try
            {
                Loan loan = _loanService.CreateLoan(createLoanDto);
                return Ok(loan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        //public ActionResult GetLoanDetails(int loanId)
        //{
        //    return Ok();
        //}
        //public ActionResult CreateLoan()
        //{
        //    return Ok();
        //}

        //public ActionResult EditLoanInformation() { }

        //public ActionResult BlockLoanPayments() { }

        //public ActionResult CancelLoan() { }

        //public ActionResult DesembolsarPrestmao() { }


    }
}
