using NegocioInversiones.Models.LoanModel;
using NegocioInversiones.Models.LoanModel.Dto;

namespace NegocioInversiones.Interfaces
{
    public interface ILoanService
    {
        Loan CreateLoan(CreateLoanDto loanDto);
    }
}
