import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorBalanceReportComponent } from './vendor-balance-report.component';

describe('VendorBalanceReportComponent', () => {
  let component: VendorBalanceReportComponent;
  let fixture: ComponentFixture<VendorBalanceReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorBalanceReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorBalanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
