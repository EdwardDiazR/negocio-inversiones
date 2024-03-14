using System.ComponentModel.DataAnnotations;

namespace NegocioInversiones.Models.SolicitudModels
{
    public class LoanRequest
    {

        [Key]
        public long Id { get; set; }
        public long GeneralRequestId { get; set; }
        public DateTime RequestDate { get; init; } = DateTime.Now;

        public double RequestedLoanAmount { get; set; }
        public int RequestedLoanTime { get; set; }
        public int LoanType { get; set; }
        public string ? Description { get; set; }
        public double LoanAmount { get; set; }
        public int CustomerId { get; set; }
        public int RequestStatus { get; set; }
        public bool IsClosed { get; set; }
        public double ApprovedAmount { get; set; }
        public double ApprovedInterestRate { get; set; }
        public int ApprovedTimeInMonths { get; set; }
        public DateTime RequestClosingDate { get; set; }
        public int EmployeeCode { get; set; }

    }
}
