import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CostCenterAccountReportComponent } from './cost-center-account-report.component';

describe('CostCenterAccountReportComponent', () => {
  let component: CostCenterAccountReportComponent;
  let fixture: ComponentFixture<CostCenterAccountReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CostCenterAccountReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CostCenterAccountReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
