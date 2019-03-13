import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LastNamesComponent } from './last-names.component';

describe('LastNamesComponent', () => {
  let component: LastNamesComponent;
  let fixture: ComponentFixture<LastNamesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LastNamesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LastNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
