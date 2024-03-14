 interface CreateLoanRequestDto {
    LoanAmount:number;
    LoanType:number;
    LoanTimeInMonths:number;
    CustomerId:number;
    CustomerCivilId:string;

}
interface LoanRequest{
    id:number;
    requestDate:string;
    requestedLoanAmount:string;
    requestedLoanTime:string;
    requestStatus:number;
    isClosed:boolean;
    loanType:number;
    loanTypeMessage:string;
    statusMessage:string;
    generalRequestId:number
    description:string;
    requestClosingDate:string
}
export {CreateLoanRequestDto,LoanRequest}
