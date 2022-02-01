import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DespesaModel } from '../model/DespesaModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};


@Injectable({
  providedIn: 'root'
})
export class DespesaService {

  url = 'api/Despesa';

constructor(private http: HttpClient) { }

  ObterTodos(): Observable<DespesaModel[]> {
    return this.http.get<DespesaModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<DespesaModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<DespesaModel>(apiUrl);
  }

  Inserir(Despesa: DespesaModel): Observable<any> {
    return this.http.post(this.url, Despesa, httpOptions);
  }

  Atualizar(id:number, Despesa: DespesaModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Despesa, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
