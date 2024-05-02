import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageThankComponent } from './page-thank.component';

describe('PageThankComponent', () => {
  let component: PageThankComponent;
  let fixture: ComponentFixture<PageThankComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageThankComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageThankComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
