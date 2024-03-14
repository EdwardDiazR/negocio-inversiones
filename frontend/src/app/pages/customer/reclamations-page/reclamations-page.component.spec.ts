import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReclamationsPageComponent } from './reclamations-page.component';

describe('ReclamationsPageComponent', () => {
  let component: ReclamationsPageComponent;
  let fixture: ComponentFixture<ReclamationsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReclamationsPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReclamationsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
