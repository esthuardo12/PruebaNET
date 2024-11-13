import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObtenerRegistroComponent } from './obtener-registro.component';

describe('ObtenerRegistroComponent', () => {
  let component: ObtenerRegistroComponent;
  let fixture: ComponentFixture<ObtenerRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ObtenerRegistroComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ObtenerRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
