import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageBookDetailComponent } from './page-book-detail.component';

describe('PageBookDetailComponent', () => {
  let component: PageBookDetailComponent;
  let fixture: ComponentFixture<PageBookDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageBookDetailComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageBookDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
