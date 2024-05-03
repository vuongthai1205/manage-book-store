import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageManageOrderComponent } from './page-manage-order.component';

describe('PageManageOrderComponent', () => {
  let component: PageManageOrderComponent;
  let fixture: ComponentFixture<PageManageOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageManageOrderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageManageOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
