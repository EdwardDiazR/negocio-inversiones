import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CreateCustomerDto, Customer } from '../../Models/customer';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiBaseUrl: string = 'https://localhost:7298/api/v2/customer';

  constructor(private _http: HttpClient) {}

  public _customerResultObservable: BehaviorSubject<Customer | null> =
    new BehaviorSubject<Customer | null>(null);

  get _customerResult() {
    return this._customerResultObservable.asObservable();
  }

  createCustomerProfile(
    createCustomerDto: CreateCustomerDto
  ): Observable<Customer> {
    return this._http.post<Customer>(
      `${this.apiBaseUrl}/create-customer`,
      createCustomerDto
    );
  }

  getCustomerById(CustomerId: number) {
    const parametros: HttpParams = new HttpParams({
      fromObject: { CustomerId: CustomerId},
    });
    return this._http.get<Customer>(`${this.apiBaseUrl}/customer-profile`, {
      params: parametros,
    });
  }

  getCustomerByCivilId(CustomerId: string, CustomerIdType: number) {
    const parametros: HttpParams = new HttpParams({
      fromObject: { CustomerId: CustomerId, CustomerIdType: CustomerIdType },
    });
    return this._http.get<Customer>(`${this.apiBaseUrl}/customer-profile`, {
      params: parametros,
    });
  }
}
