import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppMainComponent } from './app-main.component';

describe('AppMainComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppMainComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppMainComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'mersal-accounting-app'`, () => {
    const fixture = TestBed.createComponent(AppMainComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('mersal-accounting-app');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppMainComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Welcome to mersal-accounting-app!');
  });
});
