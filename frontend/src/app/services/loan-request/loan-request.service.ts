import { Injectable } from '@angular/core';
import { CreateLoanRequestDto, LoanRequest } from '../../Models/loan-request';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class LoanRequestService {
  constructor(private _http: HttpClient) {}
  apiBaseUrl: string = 'https://localhost:7298/api/v2/loan-request';

  createLoanRequest(dto: CreateLoanRequestDto) {
    return this._http.post(`${this.apiBaseUrl}/create-loan-request`, dto);
  }

  getLoanRequests(customerId: number) {
    const params = new HttpParams({
      fromObject: {
        CustomerId: customerId,
      },
    });
    return this._http.get<LoanRequest[]>(
      `${this.apiBaseUrl}/customer-loan-requests`,
      {
        params: params,
      }
    );
  }
}
