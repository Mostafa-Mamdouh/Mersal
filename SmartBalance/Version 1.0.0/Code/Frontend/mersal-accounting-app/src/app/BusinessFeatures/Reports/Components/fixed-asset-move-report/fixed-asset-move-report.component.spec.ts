import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BankAccountReportComponent } from './bank-account-report.component';

describe('BankAccountReportComponent', () => {
  let component: BankAccountReportComponent;
  let fixture: ComponentFixture<BankAccountReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BankAccountReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BankAccountReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
