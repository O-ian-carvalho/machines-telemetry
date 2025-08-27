import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelemetriesListComponent } from './telemetries-list.component';

describe('TelemetriesListComponent', () => {
  let component: TelemetriesListComponent;
  let fixture: ComponentFixture<TelemetriesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TelemetriesListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TelemetriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
