import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SampleEditorComponent } from './sample-editor.component';

describe('SampleEditorComponent', () => {
  let component: SampleEditorComponent;
  let fixture: ComponentFixture<SampleEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SampleEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SampleEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
