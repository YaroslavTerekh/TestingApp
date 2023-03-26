import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompleteTestComponent } from './complete-test.component';

describe('CompleteTestComponent', () => {
  let component: CompleteTestComponent;
  let fixture: ComponentFixture<CompleteTestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompleteTestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompleteTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
