using NegocioInversiones.Models.LoanRequest;
using NegocioInversiones.Models.SolicitudModels;

namespace NegocioInversiones.Interfaces
{
    public interface ILoanRequestService
    {
        List<LoanRequest> GetCustomerLoanRequests(int CustomerId);
        LoanRequest CreateLoanRequest(CreateLoanRequestDto loanRequestDto);
    }
}
