import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageLabelComponent } from './page-label.component';

describe('PageLabelComponent', () => {
  let component: PageLabelComponent;
  let fixture: ComponentFixture<PageLabelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageLabelComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PageLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
