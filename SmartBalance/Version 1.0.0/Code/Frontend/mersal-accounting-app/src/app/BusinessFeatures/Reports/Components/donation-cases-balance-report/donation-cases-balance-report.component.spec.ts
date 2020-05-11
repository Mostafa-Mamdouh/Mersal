import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonationCasesBalanceReportComponent } from './donation-cases-balance-report.component';

describe('DonationCasesBalanceReportComponent', () => {
  let component: DonationCasesBalanceReportComponent;
  let fixture: ComponentFixture<DonationCasesBalanceReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonationCasesBalanceReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonationCasesBalanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
