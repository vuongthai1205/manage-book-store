import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupOrderComponent } from './popup-order.component';

describe('PopupOrderComponent', () => {
  let component: PopupOrderComponent;
  let fixture: ComponentFixture<PopupOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PopupOrderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PopupOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
