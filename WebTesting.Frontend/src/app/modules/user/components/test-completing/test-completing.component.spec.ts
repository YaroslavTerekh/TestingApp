import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TestCompletingComponent } from './test-completing.component';

describe('TestCompletingComponent', () => {
  let component: TestCompletingComponent;
  let fixture: ComponentFixture<TestCompletingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TestCompletingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TestCompletingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
