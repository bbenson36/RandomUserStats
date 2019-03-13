import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FemaleRatioComponent } from './female-ratio.component';

describe('FemaleRatioComponent', () => {
  let component: FemaleRatioComponent;
  let fixture: ComponentFixture<FemaleRatioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FemaleRatioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FemaleRatioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
