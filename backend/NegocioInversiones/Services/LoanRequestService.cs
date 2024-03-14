using Microsoft.EntityFrameworkCore;
using NegocioInversiones.Data;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.LoanRequest;
using NegocioInversiones.Models.Request;
using NegocioInversiones.Models.SolicitudModels;

namespace NegocioInversiones.Services
{
    public class LoanRequestService : ILoanRequestService
    {
        private readonly SqlServerContext _db;
        public LoanRequestService(SqlServerContext sqlServerContext)
        {
            _db = sqlServerContext;
        }

        public List<LoanRequest> GetCustomerLoanRequests(int CustomerId)
        {
            List<LoanRequest> loanRequest = _db.LoanRequest.Where(l => l.CustomerId == CustomerId).ToList();

            return loanRequest;
        }
        public LoanRequest CreateLoanRequest(CreateLoanRequestDto loanRequestDto)
        {
            try
            {
                _db.ChangeTracker.Clear();
                _db.Database.BeginTransaction();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LoanRequest ON");


                Request request = new Request()
                {
                    CustomerId = loanRequestDto.CustomerId,
                    Date = DateTime.Now,
                    Type = 1
                };

                _db.Request.Add(request);
                _db.SaveChanges();

                LoanRequest loanRequest = new LoanRequest()
                {
                    GeneralRequestId = request.Id,
                    ApprovedAmount = 0,
                    LoanAmount = loanRequestDto.LoanAmount,
                    ApprovedInterestRate = 0,
                    ApprovedTimeInMonths = 0,
                    IsClosed = false,
                    EmployeeCode = 0,
                    CustomerId = loanRequestDto.CustomerId,
                    RequestDate = DateTime.Now,
                    RequestStatus = 1,
                    RequestClosingDate = DateTime.Now.AddYears(1),
                    RequestedLoanAmount = loanRequestDto.LoanAmount,
                    RequestedLoanTime = loanRequestDto.LoanTimeInMonths,
                    LoanType = loanRequestDto.LoanType,
                    Description = " "
                };

                _db.LoanRequest.Add(loanRequest);
                _db.SaveChanges();
                _db.Database.CommitTransaction();



                return loanRequest;
            }
            catch (Exception ex)
            {
                _db.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
            finally
            {
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.LoanRequest OFF");

            }



        }
    }
}
