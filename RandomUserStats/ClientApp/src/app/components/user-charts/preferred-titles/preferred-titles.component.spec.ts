import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PreferredTitlesComponent } from './preferred-titles.component';

describe('PreferredTitlesComponent', () => {
  let component: PreferredTitlesComponent;
  let fixture: ComponentFixture<PreferredTitlesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PreferredTitlesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PreferredTitlesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
