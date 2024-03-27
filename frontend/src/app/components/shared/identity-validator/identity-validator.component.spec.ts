import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentityValidatorComponent } from './identity-validator.component';

describe('IdentityValidatorComponent', () => {
  let component: IdentityValidatorComponent;
  let fixture: ComponentFixture<IdentityValidatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [IdentityValidatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IdentityValidatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
