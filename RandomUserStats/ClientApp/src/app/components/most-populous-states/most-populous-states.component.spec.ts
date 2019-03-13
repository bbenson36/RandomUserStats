import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostPopulousStatesComponent } from './most-populous-states.component';

describe('MostPopulousStatesComponent', () => {
  let component: MostPopulousStatesComponent;
  let fixture: ComponentFixture<MostPopulousStatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostPopulousStatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostPopulousStatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
