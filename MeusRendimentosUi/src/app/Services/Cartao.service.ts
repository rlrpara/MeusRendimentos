import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cartao } from '../Models/Cartao';
import { Categoria } from '../Models/Categoria';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CartaoService {

  url = 'api/cartao';

constructor(private http: HttpClient) { }

PegarTodas(): Observable<Cartao[]> {
  return this.http.get<Cartao[]>(this.url);
}

PegarPeloId(id: number): Observable<Cartao> {
  const apiUrl = `${this.url}/${id}`;
  return this.http.get<Cartao>(apiUrl);
}

Inserir(cartao : Cartao) : Observable<any> {
  return this.http.post(this.url, cartao, httpOptions);
}

Atualizar(id : number, categoria : Categoria) : Observable<any> {
  const apiUrl = `${this.url}/${id}`;
  return this.http.put<Cartao>(apiUrl, categoria, httpOptions);
}

Excluir(id: number): Observable<any> {
  const apiUrl = `${this.url}/${id}`;
  return this.http.delete<number>(apiUrl, httpOptions);
}

}
