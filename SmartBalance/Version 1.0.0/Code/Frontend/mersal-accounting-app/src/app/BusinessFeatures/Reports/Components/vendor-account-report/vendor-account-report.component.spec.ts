import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorAccountReportComponent } from './vendor-account-report.component';

describe('VendorAccountReportComponent', () => {
  let component: VendorAccountReportComponent;
  let fixture: ComponentFixture<VendorAccountReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorAccountReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorAccountReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
