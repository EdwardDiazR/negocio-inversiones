import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../services/customer/customer.service';
import { Customer } from '../../../Models/customer';
import { DividerComponent } from '../../../components/shared/divider/divider.component';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-information-page',
  standalone: true,
  imports: [DividerComponent,DatePipe],
  templateUrl: './information-page.component.html',
  styleUrl: './information-page.component.scss',
})
export class InformationPageComponent implements OnInit {
  constructor(private _customerService: CustomerService) {}

  customer!: Customer;
  customerFullName!: String;
  customerDobFormatted!: string;

  userRole!:string;
  ngOnInit(): void {
    this.userRole='REPRESENTANTE'
    this._customerService._customerResult.subscribe({
      next: (res) => {
        console.log(res);

        this.customer = res as Customer;
      },
    });

    this.customerDobFormatted = new Date(
      this.customer.customerDob
    ).toLocaleDateString();

    this.customerFullName =
      this.customer.firstName +
      ' ' +
      (this.customer.middleName && this.customer.middleName + ' ') +
      this.customer.lastName +
      ' ' +
      (this.customer.secondLastName && this.customer.secondLastName);
  }
}
