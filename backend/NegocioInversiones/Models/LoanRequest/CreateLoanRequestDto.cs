namespace NegocioInversiones.Models.LoanRequest
{
    public class CreateLoanRequestDto
    {
        public double LoanAmount { get; set; }
        public int LoanType { get; set; }
        public int LoanTimeInMonths { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCivilId { get; set; }


    }
}
