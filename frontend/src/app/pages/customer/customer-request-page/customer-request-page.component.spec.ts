import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerRequestPageComponent } from './customer-request-page.component';

describe('CustomerRequestPageComponent', () => {
  let component: CustomerRequestPageComponent;
  let fixture: ComponentFixture<CustomerRequestPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerRequestPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CustomerRequestPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
