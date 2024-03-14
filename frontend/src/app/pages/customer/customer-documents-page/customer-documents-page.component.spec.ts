import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerDocumentsPageComponent } from './customer-documents-page.component';

describe('CustomerDocumentsPageComponent', () => {
  let component: CustomerDocumentsPageComponent;
  let fixture: ComponentFixture<CustomerDocumentsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerDocumentsPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CustomerDocumentsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
