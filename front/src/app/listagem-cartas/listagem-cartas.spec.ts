import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListagemCartas } from './listagem-cartas';

describe('ListagemCartas', () => {
  let component: ListagemCartas;
  let fixture: ComponentFixture<ListagemCartas>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListagemCartas]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListagemCartas);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
