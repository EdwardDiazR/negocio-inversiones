interface Loan {}

interface CreateLoanDto {
  Amount: Number;
  BeneficiaryCustomerId: string;
  CoSignerId: number | null;
  GuaranteeTypeId: number;
  Interest: number;
  LoanTypeId: number;
  MesesTasaFija: number;
  PlazoEnMeses: number;
}

export { Loan, CreateLoanDto };
