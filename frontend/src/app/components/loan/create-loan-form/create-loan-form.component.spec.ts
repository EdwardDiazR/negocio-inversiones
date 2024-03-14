import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLoanFormComponent } from './create-loan-form.component';

describe('CreateLoanFormComponent', () => {
  let component: CreateLoanFormComponent;
  let fixture: ComponentFixture<CreateLoanFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateLoanFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateLoanFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
