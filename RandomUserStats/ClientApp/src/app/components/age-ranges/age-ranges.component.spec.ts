import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AgeRangesComponent } from './age-ranges.component';

describe('AgeRangesComponent', () => {
  let component: AgeRangesComponent;
  let fixture: ComponentFixture<AgeRangesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AgeRangesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AgeRangesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
