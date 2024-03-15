namespace NegocioInversiones.Models.LoanModel.Dto
{
    public record CreateLoanDto()
    {
        public int LoanTypeId { get; set; }
        public int BeneficiaryCustomerId { get; set; }
        public int ? CoSignerId { get; set; }
        public double Amount { get; set; }
        public double Interest {  get; set; }
        public int MesesTasaFija { get; set; }
        public int GuaranteeTypeId { get; set; }
        public int PlazoEnMeses { get; set; }
    
    }
}
