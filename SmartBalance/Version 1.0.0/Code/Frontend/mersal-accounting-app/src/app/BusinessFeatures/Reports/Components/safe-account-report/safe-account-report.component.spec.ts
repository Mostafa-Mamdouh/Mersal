import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafeAccountReportComponent } from './safe-account-report.component';

describe('SafeAccountReportComponent', () => {
  let component: SafeAccountReportComponent;
  let fixture: ComponentFixture<SafeAccountReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafeAccountReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafeAccountReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
