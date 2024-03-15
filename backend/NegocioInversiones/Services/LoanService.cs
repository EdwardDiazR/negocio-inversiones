using Microsoft.EntityFrameworkCore;
using NegocioInversiones.Data;
using NegocioInversiones.Interfaces;
using NegocioInversiones.Models.CustomerModels;
using NegocioInversiones.Models.CustomerProduct;
using NegocioInversiones.Models.LoanModel;
using NegocioInversiones.Models.LoanModel.Dto;

namespace NegocioInversiones.Services
{
    public class LoanService : ILoanService
    {
        private SqlServerContext _db;
        private ICustomerService _customerService;
        public LoanService(SqlServerContext sqlServerContext, ICustomerService customerService)
        {
            _db = sqlServerContext;
            _customerService = customerService;
        }

        public Loan CreateLoan(CreateLoanDto loanDto)
        {
            try
            {
                bool CustomerExists = _customerService.CheckIfCustomerExists(loanDto.BeneficiaryCustomerId);

                if (!CustomerExists)
                {
                    throw new Exception("Cliente no existe con ese ID");
                }

                _db.ChangeTracker.Clear();

                _db.Database.BeginTransaction();
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Loan ON");

                //TODO: Create a 'Product Catalog in db' then, check if product type ID exists in that database
                //TODO: Create a 'Product Catalog in db' then, check if product type ID exists in that database
                //It helps to not add a product typa that doesn't exists in our database
               

                CustomerProduct product = new CustomerProduct()
                {
                    ProductType = 1,
                    CustomerId = loanDto.BeneficiaryCustomerId
                };

                _db.CustomerProduct.Add(product);
                _db.SaveChanges();

                Loan loan = new Loan()
                {
                    Id = product.Id,
                    BeneficiaryCustomerId = product.CustomerId,
                    LoanTypeId = product.ProductType,
                    Amount = loanDto.Amount,
                    CancellationAmount = loanDto.Amount + 0,
                    CapitalBalance = loanDto.Amount,
                    CoSignerId = loanDto.CoSignerId,
                    Interest = loanDto.Interest,
                    InterestBalance = 0,                    
                    GuaranteeTypeId = loanDto.GuaranteeTypeId,
                    MontoMora= 0,
                    MontoCuota = 0,
                    LoanStatusId = 1,
                    PlazoEnMeses = loanDto.PlazoEnMeses,
                    MesesTasaFija = loanDto.MesesTasaFija,
                    IsBlocked = true,
                    IsInLegal = false,
                    IsWithdrawn = false,
                    IsCancelled = false,
                };

                _db.Loan.Add(loan);
                _db.SaveChanges();

                _db.Database.CommitTransaction();

                return loan;
            }
            catch (Exception ex)
            {
                _db.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
            finally
            {
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Loan OFF");

            }



        }
    }
}
