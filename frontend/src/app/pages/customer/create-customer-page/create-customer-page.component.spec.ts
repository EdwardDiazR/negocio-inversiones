import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCustomerPageComponent } from './create-customer-page.component';

describe('CreateCustomerPageComponent', () => {
  let component: CreateCustomerPageComponent;
  let fixture: ComponentFixture<CreateCustomerPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateCustomerPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateCustomerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
