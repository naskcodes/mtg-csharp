import { Component, OnInit, signal } from '@angular/core';
import { Carta } from '../../services/carta';

@Component({
  selector: 'app-listagem-cartas',
  imports: [],
  templateUrl: './listagem-cartas.html',
  styleUrl: './listagem-cartas.scss',
})
export class ListagemCartas implements OnInit {
  dados = signal<any>(null);
  
  constructor(private srv: Carta) {  }

  ngOnInit(): void {
    this.srv.ListaCartas().subscribe({
      next: (result) => {
        this.dados.set(result);
      }
    })
  }
}