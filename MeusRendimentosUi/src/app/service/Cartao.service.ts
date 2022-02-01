import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartaoModel } from '../model/CartaoModel';

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

  ObterTodos(): Observable<CartaoModel[]> {
    return this.http.get<CartaoModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<CartaoModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<CartaoModel>(apiUrl);
  }

  Inserir(cartao: CartaoModel): Observable<any> {
    return this.http.post(this.url, cartao, httpOptions);
  }

  Atualizar(id:number, cartao: CartaoModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, cartao, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}

