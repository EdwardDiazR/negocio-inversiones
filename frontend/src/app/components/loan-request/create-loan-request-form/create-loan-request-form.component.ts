import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../services/customer/customer.service';
import { Customer } from '../../../Models/customer';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CreateLoanRequestDto } from '../../../Models/loan-request';
import { LoanRequestService } from '../../../services/loan-request/loan-request.service';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-create-loan-request-form',
  standalone: true,
  imports: [ReactiveFormsModule,CurrencyPipe],
  templateUrl: './create-loan-request-form.component.html',
  styleUrl: './create-loan-request-form.component.scss',
})
export class CreateLoanRequestFormComponent implements OnInit {
  constructor(
    private _customerService: CustomerService,
    private _loanRequestService: LoanRequestService
  ) {}

  customer!: Customer;
  // LoanAmount:number;
  // LoanType:number;
  // LoanTimeInMonths:number;
  // CustomerId:number;
  // CustomerCivilId:string;
  CreateLoanRequestForm!: FormGroup;

  LoanRequest!: CreateLoanRequestDto;

  ngOnInit(): void {
    this._customerService._customerResult.subscribe({
      next: (res) => {
        this.customer = res as Customer;

        this.CreateLoanRequestForm = new FormGroup({
          LoanAmount: new FormControl(null, [Validators.required]),
          LoanType: new FormControl(null, [Validators.required]),
          LoanTimeInMonths: new FormControl(null, [
            Validators.required,
            Validators.min(1),
          ]),
          CustomerId: new FormControl(this.customer.id, [Validators.required]),
          CustomerCivilId: new FormControl(this.customer.civilId, [
            Validators.required,
          ]),
        });
      },
    });
  }

  createLoanRequest() {
    this.LoanRequest = <CreateLoanRequestDto>{
      CustomerCivilId: this.CreateLoanRequestForm.value.CustomerCivilId,
      CustomerId: this.CreateLoanRequestForm.value.CustomerId,
      LoanAmount: this.CreateLoanRequestForm.value.LoanAmount,
      LoanTimeInMonths: this.CreateLoanRequestForm.value.LoanTimeInMonths,
      LoanType: this.CreateLoanRequestForm.value.LoanType,
    };

    this._loanRequestService.createLoanRequest(this.LoanRequest).subscribe({
      next: (res) => {
        console.log(res);
      },
    });
  }
}
