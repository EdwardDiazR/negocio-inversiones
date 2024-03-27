import { NgClass } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CreateLoanDto } from '../../../Models/loan';
import { Customer } from '../../../Models/customer';
import { CustomerService } from '../../../services/customer/customer.service';
import { LoanService } from '../../../services/loan/loan.service';
import { DividerComponent } from '../../shared/divider/divider.component';
import { IdentityValidatorComponent } from '../../shared/identity-validator/identity-validator.component';

@Component({
  selector: 'app-create-loan-form',
  standalone: true,
  imports: [
    NgClass,
    ReactiveFormsModule,
    FormsModule,
    DividerComponent,
    IdentityValidatorComponent,
  ],
  templateUrl: './create-loan-form.component.html',
  styleUrl: './create-loan-form.component.scss',
})
export class CreateLoanFormComponent implements OnInit {
  constructor(
    private _customerService: CustomerService,
    private _loanService: LoanService
  ) {}
  plazoMaximoEnMeses: number[] = Array.from({ length: 60 }, (_, i) => i + 1);
  showValidator: boolean = true;
  createLoanForm!: FormGroup;
  loan!: CreateLoanDto;
  isLoadingCustomerInfo!:boolean
  apiError!:string
  isSubmitted:boolean = false;

  customerQueryForm = new FormGroup({
    customerCivilId: new FormControl(null, [
      Validators.required,
      // Validators.minLength(11),
    ]),
    customerCivilIdType: new FormControl(1, [Validators.required]),
  });
  customer!: Customer;

  validateCustomer(info: any) {
    (this.customerQueryForm.value.customerCivilId = info.CustomerId),
      (this.customerQueryForm.value.customerCivilIdType = info.CustomerIdType);

    if (info.CustomerId && info.CustomerIdType) {
      this.getCustomerInformation();
    }
  }

  getCustomerInformation() {

    this.isLoadingCustomerInfo = true;
    this.isSubmitted = true
    let id = this.customerQueryForm.value.customerCivilId || '';
    let idType = this.customerQueryForm.value.customerCivilIdType || 0;

    // id = "4020894456"
    // idType = 1
    this._customerService.getCustomerByCivilId(id, idType).subscribe({
      next: (res) => {
        this.customer = res;
        this.showValidator = false;
      
      },error:(e)=>{this.apiError=e.error}
    });
    this.isLoadingCustomerInfo=false
  }

  ngOnInit(): void {
    this.createLoanForm = new FormGroup({
      BeneficiaryCustomerId: new FormControl(null, [Validators.required]),
      CoSignerId: new FormControl(null, []),
      Amount: new FormControl(null, [
        Validators.required,
        Validators.min(1000),
      ]),
      Interest: new FormControl(null, [Validators.required]),
      PlazoEnMeses: new FormControl(null, [
        Validators.required,
        Validators.min(1),
      ]),
      LoanTypeId: new FormControl(1, [Validators.required]),
      MesesTasaFija: new FormControl(0, [Validators.required]),
      GuaranteeTypeId: new FormControl(1, [Validators.required]),
    });
  }

  createLoan() {
    if (this.createLoanForm.valid && this.customer) {
      this.loan = <CreateLoanDto>{
        Amount: this.createLoanForm.value.Amount,
        BeneficiaryCustomerId: this.customer.civilId,
        CoSignerId: this.createLoanForm.value.CoSignerId || null,
        GuaranteeTypeId: this.createLoanForm.value.GuaranteeTypeId,
        Interest: this.createLoanForm.value.Interest,
        LoanTypeId: this.createLoanForm.value.LoanTypeId,
        MesesTasaFija: this.createLoanForm.value.MesesTasaFija,
        PlazoEnMeses: this.createLoanForm.value.PlazoEnMeses,
      };

      this._loanService.createLoan(this.loan).subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (e) => console.log(e),
      });
    }
  }
  // Amount: checked;
  // BeneficiaryCustomerId: checked;
  // CoSignerId: checked | null;
  // GuaranteeTypeId: number;
  // Interest: checked;
  // LoanTypeId: checked;
  // MesesTasaFija: number;
  // PlazoEnMeses: checked;
}
