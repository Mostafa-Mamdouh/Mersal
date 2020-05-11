import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryMovementEditorComponent } from './inventory-movement-editor.component';

describe('InventoryMovementEditorComponent', () => {
  let component: InventoryMovementEditorComponent;
  let fixture: ComponentFixture<InventoryMovementEditorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InventoryMovementEditorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InventoryMovementEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
