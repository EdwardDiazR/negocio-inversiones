import { Component } from '@angular/core';
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

@Component({
  selector: 'app-customer-search-page',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink, LoadingSpinnerComponent],
  templateUrl: './customer-search-page.component.html',
  styleUrl: './customer-search-page.component.scss',
})
export class CustomerSearchPageComponent {
  constructor(
    private _customerService: CustomerService,
    private _router: Router,
    _titleService: Title
  ) {
    _titleService.setTitle('Buscar cliente');
  }

  customerInfo: FormGroup = new FormGroup({
    CustomerId: new FormControl('', [Validators.required]),
    CustomerIdType: new FormControl(null, [Validators.required]),
  });

  CustomerProfile!: Customer | null;

  ApiResponseMessage!: string;

  isSubmitted: boolean = false;
  loadingCustomerInfo: boolean = false;

  searchCustomerById(): void {

    // this._router.navigate(['/customer', this.CustomerProfile?.id, 'profile'],{state:{item:this.CustomerProfile}})

    this.isSubmitted = false;
    this.CustomerProfile = null;
    this.loadingCustomerInfo = true;

    if (this.customerInfo.valid)
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
                '/customer',this.CustomerProfile.civilId,'profile'
              ]);
          },
          error: (e) => (this.ApiResponseMessage = e.error),
        });
    this.isSubmitted = true;
    this.loadingCustomerInfo = false;
  }
}
