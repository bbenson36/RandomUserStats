import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FirstNamesComponent } from './first-names.component';

describe('FirstNamesComponent', () => {
  let component: FirstNamesComponent;
  let fixture: ComponentFixture<FirstNamesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FirstNamesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FirstNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
