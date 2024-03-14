import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLoanRequestFormComponent } from './create-loan-request-form.component';

describe('CreateLoanRequestFormComponent', () => {
  let component: CreateLoanRequestFormComponent;
  let fixture: ComponentFixture<CreateLoanRequestFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateLoanRequestFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateLoanRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
