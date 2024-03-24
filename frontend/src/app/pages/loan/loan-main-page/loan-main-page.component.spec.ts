import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanMainPageComponent } from './loan-main-page.component';

describe('LoanMainPageComponent', () => {
  let component: LoanMainPageComponent;
  let fixture: ComponentFixture<LoanMainPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoanMainPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LoanMainPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
