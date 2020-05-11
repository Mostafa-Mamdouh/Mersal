import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafeBalanceReportComponent } from './safe-balance-report.component';

describe('SafeBalanceReportComponent', () => {
  let component: SafeBalanceReportComponent;
  let fixture: ComponentFixture<SafeBalanceReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafeBalanceReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafeBalanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
