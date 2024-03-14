import { Component } from '@angular/core';
import { CreateCustomerFormComponent } from '../../../components/customer/create-customer-form/create-customer-form.component';
import { DividerComponent } from '../../../components/shared/divider/divider.component';

@Component({
  selector: 'app-create-customer-page',
  standalone: true,
  imports: [CreateCustomerFormComponent,DividerComponent],
  templateUrl: './create-customer-page.component.html',
  styleUrl: './create-customer-page.component.scss'
})
export class CreateCustomerPageComponent {

}
