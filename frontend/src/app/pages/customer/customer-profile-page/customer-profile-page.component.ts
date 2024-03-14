import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../../services/customer/customer.service';
import { Customer } from '../../../Models/customer';
import { ActivatedRoute, Route, RouterLink, RouterOutlet } from '@angular/router';
import { LoadingSpinnerComponent } from '../../../components/shared/loading-spinner/loading-spinner.component';
import { timeInterval } from 'rxjs';

@Component({
  selector: 'app-customer-profile-page',
  standalone: true,
  imports: [RouterOutlet,RouterLink,LoadingSpinnerComponent],
  templateUrl: './customer-profile-page.component.html',
  styleUrl: './customer-profile-page.component.scss',
})
export class CustomerProfilePageComponent implements OnInit {
  constructor(
    private _customerService: CustomerService,
    private _route: ActivatedRoute
  ) {}

  customerProfile!: Customer;

  customerRouteId!: any;

  isLoadingProfile:boolean= false;

  ngOnInit(): void {

    this.isLoadingProfile= true;
    this.customerRouteId = this._route.snapshot.params['customerId'] || null;



    console.log('En el parametro:' + this.customerRouteId);

    this._customerService._customerResult.subscribe({
      next: (res) => {
        if (!res) {

          // Notification.requestPermission().then(per=>{
          //   if(per === 'granted'){
          //     new Notification('No se encontro usuario, llamando a la API...')
          //   }
          // })
          this._customerService
            .getCustomerById(this.customerRouteId) //TODO: Try get user by id, and other method to get by CivilId and DocTYpe
            .subscribe({
              next: (res) => {
                this.customerProfile = res as Customer;
                this._customerService._customerResultObservable.next(res);

                this.isLoadingProfile= false;

              },
              error: (e) => {
                //TODO: HANDLE ERROR WITH A MESSAGE ETC
                this.isLoadingProfile= false;
                
                console.log(e.status);
              },
            });
        } else {
          this.customerProfile = res as Customer;
          this.isLoadingProfile= false;
        }
      },
      error: (e) => {
        console.log(e);
      },
    });
  
  }
}
