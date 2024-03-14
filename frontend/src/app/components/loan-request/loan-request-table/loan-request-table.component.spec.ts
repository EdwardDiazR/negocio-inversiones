import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanRequestTableComponent } from './loan-request-table.component';

describe('LoanRequestTableComponent', () => {
  let component: LoanRequestTableComponent;
  let fixture: ComponentFixture<LoanRequestTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoanRequestTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoanRequestTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
