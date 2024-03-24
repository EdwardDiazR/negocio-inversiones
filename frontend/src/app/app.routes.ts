import { Routes } from '@angular/router';
import { CreateCustomerPageComponent } from './pages/customer/create-customer-page/create-customer-page.component';
import { CustomerSearchPageComponent } from './pages/customer/customer-search-page/customer-search-page.component';
import { CustomerProfilePageComponent } from './pages/customer/customer-profile-page/customer-profile-page.component';
import { CustomerDocumentsPageComponent } from './pages/customer/customer-documents-page/customer-documents-page.component';
import { ReclamationsPageComponent } from './pages/customer/reclamations-page/reclamations-page.component';
import { InformationPageComponent } from './pages/customer/information-page/information-page.component';
import { CustomerRequestPageComponent } from './pages/customer/customer-request-page/customer-request-page.component';
import { CreateLoanRequestFormComponent } from './components/loan-request/create-loan-request-form/create-loan-request-form.component';
import { LoanRequestTableComponent } from './components/loan-request/loan-request-table/loan-request-table.component';
import { LoanMainPageComponent } from './pages/loan/loan-main-page/loan-main-page.component';
import { CreateLoanFormComponent } from './components/loan/create-loan-form/create-loan-form.component';

export const routes: Routes = [
  { path: '', redirectTo: 'customer/search', pathMatch: 'full' },
  {
    path: 'loan',
    component: LoanMainPageComponent,
    children: [],
  },
  { path: 'loan/create', component: CreateLoanFormComponent },
  { path: 'customer/search', component: CustomerSearchPageComponent },
  { path: 'customer/crear-perfil', component: CreateCustomerPageComponent },
  {
    path: 'customer/:customerId',
    component: CustomerProfilePageComponent,
    children: [
      {
        path: 'profile',
        component: InformationPageComponent,
        pathMatch: 'full',
      },
      { path: 'documents', component: CustomerDocumentsPageComponent },
      { path: 'reclamations', component: ReclamationsPageComponent },
      {
        path: 'solicitudes',
        component: CustomerRequestPageComponent,
        children: [
          { path: '', redirectTo: 'resumen', pathMatch: 'full' },
          {
            path: 'resumen',
            component: LoanRequestTableComponent,
            pathMatch: 'full',
          },
          { path: 'crear', component: CreateLoanRequestFormComponent },
        ],
      },
    ],
  },
];
