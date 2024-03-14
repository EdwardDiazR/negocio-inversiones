using System.ComponentModel.DataAnnotations;

namespace NegocioInversiones.Models.LoanModel
{
    public class Loan
    {
        [Key]
        public long Id { get; set; }
        public int LoanStatusId { get; set; }
        public int LoanTypeId { get; set; }
        public int CustomerId { get; set; }
        public double LoanAmount { get; set; }
        public double MontoCapital { get; set; }
        public double MontoInteres { get; set; }
        public double SaldoCancelacion { get; set; }
        public double MontoCuota { get; set; }
        public double MontoMora { get; set; }
        public double InterestRate { get; set; }
        public int DiasEnAtraso { get; set; }
        public int TasaFijaEnMeses { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int GuaranteeTypeId { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsInLegal { get; set; }
    }
}
