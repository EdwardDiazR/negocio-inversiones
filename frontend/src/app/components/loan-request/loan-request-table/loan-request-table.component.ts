import { Component } from '@angular/core';
import { CreateLoanRequestFormComponent } from '../create-loan-request-form/create-loan-request-form.component';
import { CurrencyPipe, DatePipe, NgClass } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Customer } from '../../../Models/customer';
import { LoanRequest } from '../../../Models/loan-request';
import { CustomerService } from '../../../services/customer/customer.service';
import { LoanRequestService } from '../../../services/loan-request/loan-request.service';

@Component({
  selector: 'app-loan-request-table',
  standalone: true,
  imports: [
    CreateLoanRequestFormComponent,
    CurrencyPipe,
    DatePipe,
    RouterLink,
    RouterOutlet,
    NgClass
  ],
  templateUrl: './loan-request-table.component.html',
  styleUrl: './loan-request-table.component.scss',
})
export class LoanRequestTableComponent {
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

    this._loanRequestServices.getLoanRequests(this.customer.id).subscribe({
      next: (res) => {
        this.customerLoanRequests = res;

        this.customerLoanRequests.forEach((l) => {
          switch (l.requestStatus) {
            case 1 : l.statusMessage = 'Abierta'
            break;
            case 2 :l.statusMessage ='Cerrada favorable'
            break;
            case 3: l.statusMessage = 'Cerrada desfavorable'
          }
          switch (l.loanType) {
            case 1:
              l.loanTypeMessage = 'CONSUMO';
          }
        });
      },
    });
  }
}
