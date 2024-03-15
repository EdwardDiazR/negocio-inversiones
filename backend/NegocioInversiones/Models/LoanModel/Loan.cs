using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegocioInversiones.Models.LoanModel
{
    [Table("loan")]
    public class Loan
    {
        public long Id { get; set; }
        public int LoanStatusId { get; set; }
        public int LoanTypeId { get; set; }
        public int BeneficiaryCustomerId { get; init; }
        public int ? CoSignerId { get; set; }
        public double Amount { get; set; }
        public double CapitalBalance { get; set; }
        public double InterestBalance { get; set; }
        public double CancellationAmount { get; set; }
        public double MontoCuota { get; set; }
        public double MontoMora { get; set; }
        public double Interest { get; set; }
        public int PlazoEnMeses { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? EndDate { get; set; }
        public DateTime ? NextPaymentDate { get; set; }
        public int MesesTasaFija { get; set; }
        public int GuaranteeTypeId { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsBlocked { get; set; } = false;
        public bool IsInLegal { get;  set; } = false;
        public bool IsWithdrawn { get;  set; } = false;
    }
}
