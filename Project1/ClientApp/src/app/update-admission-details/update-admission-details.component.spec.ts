import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAdmissionDetailsComponent } from './update-admission-details.component';

describe('UpdateAdmissionDetailsComponent', () => {
  let component: UpdateAdmissionDetailsComponent;
  let fixture: ComponentFixture<UpdateAdmissionDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateAdmissionDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateAdmissionDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
