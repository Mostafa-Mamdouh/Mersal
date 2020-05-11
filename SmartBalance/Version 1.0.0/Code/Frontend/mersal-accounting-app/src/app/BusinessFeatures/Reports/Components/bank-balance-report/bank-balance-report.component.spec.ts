import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BankBalanceReportComponent } from './bank-balance-report.component';

describe('BankBalanceReportComponent', () => {
  let component: BankBalanceReportComponent;
  let fixture: ComponentFixture<BankBalanceReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankBalanceReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankBalanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
