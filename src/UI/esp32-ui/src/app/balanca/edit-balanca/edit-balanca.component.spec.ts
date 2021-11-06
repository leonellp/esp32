import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBalancaComponent } from './edit-balanca.component';

describe('EditBalancaComponent', () => {
  let component: EditBalancaComponent;
  let fixture: ComponentFixture<EditBalancaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditBalancaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBalancaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
