import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { Observable } from 'rxjs';

const PathUrl = environment.root + '/api/cartas/';

@Injectable({
  providedIn: 'root',
})

export class Carta {
  constructor(private http: HttpClient) {  }

  public ListaCartas(): Observable<Carta[]> {
    const url = PathUrl + `Cartas`;
    return this.http.get<Carta[]>(url);
  }
}