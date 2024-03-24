import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateLoanDto } from '../../Models/loan';

@Injectable({
  providedIn: 'root',
})
export class LoanService {
  constructor(private _http: HttpClient) {}

  apiBaseUrl: string = 'https://localhost:7298/api/v2/loan';

  createLoan(loanDto: CreateLoanDto) {
    return this._http.post(`${this.apiBaseUrl}/create-loan`, loanDto);
  }
}
