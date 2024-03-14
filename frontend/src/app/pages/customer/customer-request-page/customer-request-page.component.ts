import { Component, OnInit } from '@angular/core';
import { CreateLoanRequestFormComponent } from '../../../components/loan-request/create-loan-request-form/create-loan-request-form.component';
import { LoanRequestService } from '../../../services/loan-request/loan-request.service';
import { LoanRequest } from '../../../Models/loan-request';
import { CustomerService } from '../../../services/customer/customer.service';
import { Customer } from '../../../Models/customer';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { DividerComponent } from '../../../components/shared/divider/divider.component';

@Component({
  selector: 'app-customer-request-page',
  standalone: true,
  imports: [
    CreateLoanRequestFormComponent,
    CurrencyPipe,
    DatePipe,
    RouterLink,
    RouterOutlet,
    DividerComponent
  ],
  templateUrl: './customer-request-page.component.html',
  styleUrl: './customer-request-page.component.scss',
})
export class CustomerRequestPageComponent implements OnInit {
  customerLoanRequests!: LoanRequest[];
  customer!: Customer;

  constructor(
    private _loanRequestServices: LoanRequestService,
    private _customerService: CustomerService
  ) {}
  ngOnInit(): void {
    this._customerService._customerResult.subscribe({
      next: (r) => (this.customer = r as Customer),
    });
  }
}
