using Microsoft.EntityFrameworkCore;
using NegocioInversiones.Models.CustomerModels;
using NegocioInversiones.Models.CustomerProduct;
using NegocioInversiones.Models.LoanModel;
using NegocioInversiones.Models.Request;
using NegocioInversiones.Models.SolicitudModels;

namespace NegocioInversiones.Data
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerProduct> CustomerProduct { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<LoanRequest> LoanRequest { get; set; }

        public DbSet<Loan> Loan { get; set; }

    }
}
