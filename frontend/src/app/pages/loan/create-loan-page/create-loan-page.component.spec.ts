import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateLoanPageComponent } from './create-loan-page.component';

describe('CreateLoanPageComponent', () => {
  let component: CreateLoanPageComponent;
  let fixture: ComponentFixture<CreateLoanPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateLoanPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateLoanPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
