import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TipoModel } from '../model/TipoModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class TipoService {

  url = 'api/Tipo';

constructor(private http: HttpClient) { }

  ObterTodos(): Observable<TipoModel[]> {
    return this.http.get<TipoModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<TipoModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<TipoModel>(apiUrl);
  }

  Inserir(Tipo: TipoModel): Observable<any> {
    return this.http.post(this.url, Tipo, httpOptions);
  }

  Atualizar(id:number, Tipo: TipoModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Tipo, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
