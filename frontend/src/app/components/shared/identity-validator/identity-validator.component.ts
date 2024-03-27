import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterLink } from '@angular/router';
import { LoadingSpinnerComponent } from '../loading-spinner/loading-spinner.component';
import { Customer } from '../../../Models/customer';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-identity-validator',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, LoadingSpinnerComponent, NgClass],
  templateUrl: './identity-validator.component.html',
  styleUrl: './identity-validator.component.scss',
})
export class IdentityValidatorComponent implements OnInit {
  customerInfo: FormGroup = new FormGroup({
    CustomerId: new FormControl('', [Validators.required]),
    CustomerIdType: new FormControl(null, [Validators.required]),
  });

  CustomerProfile!: Customer | null;
  @Input() ApiResponseMessage!: string;
  @Input() isSubmitted!: boolean
  loadingCustomerInfo!: boolean ;
  showValidator: boolean = true;

  @Output() customerData = new EventEmitter<any>();
  @Output() modalToggler = new EventEmitter<boolean>();

  @Input() canCloseModal!: boolean;
  @Input() isLoading!: boolean;
  

  ngOnInit(): void {
    this.loadingCustomerInfo = this.isLoading;
  }

  validateCustomer() {
    console.log(this.isLoading);

    this.customerData.emit(this.customerInfo);
  }

  closeModal() {
    console.log(this.showValidator);

    this.modalToggler.emit((this.showValidator = false));
  }
}
