import { Component } from '@angular/core';
import { DividerComponent } from '../../shared/divider/divider.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CustomerService } from '../../../services/customer/customer.service';
import { CreateCustomerDto } from '../../../Models/customer';

@Component({
  selector: 'app-create-customer-form',
  standalone: true,
  imports: [DividerComponent, ReactiveFormsModule],
  templateUrl: './create-customer-form.component.html',
  styleUrl: './create-customer-form.component.scss',
})
export class CreateCustomerFormComponent {
  constructor(private _customerService: CustomerService) {}

  createCustomerForm: FormGroup = new FormGroup({
    customerCivilId: new FormControl('', [Validators.required]),
    customerDocumentType: new FormControl(null, [Validators.required]),
    customerFirstName: new FormControl(''),
    customerMiddleName: new FormControl(''),
    customerLastName: new FormControl(''),
    customerSecondLastName: new FormControl(''),
    customerEmail: new FormControl('', [Validators.email]),
    customerPhoneNumber: new FormControl(''),
    customerResidentialPhoneNumber: new FormControl(''),
    customerDob: new FormControl(new Date()),
    customerGender: new FormControl(null, [Validators.required]),
    customerAddress: new FormControl(''),
    customerCity: new FormControl(''),
    customerCountry: new FormControl(''),
    monthlyIncome: new FormControl(),
    customerWorkPlace: new FormControl(''),
  });

  createCustomerDto!: CreateCustomerDto;

  createProfile() {
    console.log(this.createCustomerForm.value);

    if (this.createCustomerForm.valid) {
      this.createCustomerDto = <CreateCustomerDto>{
        CustomerDocumentType: this.createCustomerForm.value.customerDocumentType,
        CustomerCivilId: this.createCustomerForm.value.customerCivilId,
        CustomerFirstName: this.createCustomerForm.value.customerFirstName,
        CustomerMiddleName: this.createCustomerForm.value.customerMiddleName,
        CustomerLastName: this.createCustomerForm.value.customerLastName,
        CustomerSecondLastName:this.createCustomerForm.value.customerSecondLastName,
        CustomerGender: this.createCustomerForm.value.customerGender,
        CustomerDob: this.createCustomerForm.value.customerDob,
        CustomerEmail: this.createCustomerForm.value.customerEmail,
        CustomerPhoneNumber: this.createCustomerForm.value.customerPhoneNumber,
        CustomerResidentialPhoneNumber: this.createCustomerForm.value.customerResidentialPhoneNumber,
        CustomerAddress: this.createCustomerForm.value.customerAddress,
        CustomerCity: this.createCustomerForm.value.customerCity,
        CustomerCountry: this.createCustomerForm.value.customerCountry,
        monthlyIncome: this.createCustomerForm.value.monthlyIncome,
        CustomerWorkPlace: this.createCustomerForm.value.customerWorkPlace,
      };
      console.log(this.createCustomerDto);

      this._customerService
        .createCustomerProfile(this.createCustomerDto)
        .subscribe((res) => console.log(res));
    }
  }
}
