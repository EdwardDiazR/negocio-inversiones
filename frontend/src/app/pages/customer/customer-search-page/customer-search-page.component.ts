import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../services/customer/customer.service';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Customer } from '../../../Models/customer';
import { Router, RouterLink } from '@angular/router';
import { Observable } from 'rxjs';
import { Title } from '@angular/platform-browser';
import { LoadingSpinnerComponent } from '../../../components/shared/loading-spinner/loading-spinner.component';
import { IdentityValidatorComponent } from '../../../components/shared/identity-validator/identity-validator.component';

@Component({
  selector: 'app-customer-search-page',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    RouterLink,
    LoadingSpinnerComponent,
    IdentityValidatorComponent,
  ],
  templateUrl: './customer-search-page.component.html',
  styleUrl: './customer-search-page.component.scss',
})
export class CustomerSearchPageComponent implements OnInit {
  constructor(
    private _customerService: CustomerService,
    private _router: Router,
    _titleService: Title
  ) {
    _titleService.setTitle('Buscar cliente');
  }

  customerInfo: FormGroup = new FormGroup({
    CustomerId: new FormControl(null, [Validators.required]),
    CustomerIdType: new FormControl(null, [Validators.required]),
  });

  CustomerProfile!: Customer | null;

  ApiResponseMessage!: string;

  isSubmitted: boolean = false;
  loadingCustomerInfo!: boolean;
  ngOnInit(): void {
    // this.loadingCustomerInfo = true;
  }

  validate(info: any) {
    this.customerInfo.value.CustomerId = info.CustomerId;
    this.customerInfo.value.CustomerIdType = info.CustomerIdType;
    // this.loadingCustomerInfo = true;

    if (info.CustomerId && info.CustomerIdType) {
      this.searchCustomerById();
    }
  }

  searchCustomerById(): void {
    // this._router.navigate(['/customer', this.CustomerProfile?.id, 'profile'],{state:{item:this.CustomerProfile}})
    this.loadingCustomerInfo = true;

    this.isSubmitted = false;
    this.CustomerProfile = null;

    this._customerService
      .getCustomerByCivilId(
        this.customerInfo.value.CustomerId,
        this.customerInfo.value.CustomerIdType
      )
      .subscribe({
        next: (res) => {
          console.log(res);
          this.CustomerProfile = res;
          this._customerService._customerResultObservable.next(
            this.CustomerProfile
          );
          console.log(this.CustomerProfile.civilId);

          this._router.navigate([
            '/customer',
            this.CustomerProfile.id,
            'profile',
          ]);
        },
        error: (e) => (this.ApiResponseMessage = e.error),
      });
    this.isSubmitted = true;
    this.loadingCustomerInfo = false;
  }
}
