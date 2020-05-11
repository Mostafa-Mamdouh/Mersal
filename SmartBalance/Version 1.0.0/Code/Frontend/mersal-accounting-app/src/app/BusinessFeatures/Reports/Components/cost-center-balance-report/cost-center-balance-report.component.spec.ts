import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CostCenterBalanceReportComponent } from './cost-center-balance-report.component';

describe('CostCenterBalanceReportComponent', () => {
  let component: CostCenterBalanceReportComponent;
  let fixture: ComponentFixture<CostCenterBalanceReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CostCenterBalanceReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CostCenterBalanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
