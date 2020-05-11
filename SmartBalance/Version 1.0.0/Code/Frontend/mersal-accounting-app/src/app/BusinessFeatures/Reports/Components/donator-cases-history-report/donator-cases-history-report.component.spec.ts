import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DonatorCasesHistoryReportComponent } from './donator-cases-history-report.component';

describe('DonatorCasesHistoryReportComponent', () => {
  let component: DonatorCasesHistoryReportComponent;
  let fixture: ComponentFixture<DonatorCasesHistoryReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DonatorCasesHistoryReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DonatorCasesHistoryReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
