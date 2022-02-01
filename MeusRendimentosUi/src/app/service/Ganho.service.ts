import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GanhoModel } from '../model/GanhoModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class GanhoService {

  url = 'api/Ganho';

constructor(private http: HttpClient) { }

  ObterTodos(): Observable<GanhoModel[]> {
    return this.http.get<GanhoModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<GanhoModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<GanhoModel>(apiUrl);
  }

  Inserir(Ganho: GanhoModel): Observable<any> {
    return this.http.post(this.url, Ganho, httpOptions);
  }

  Atualizar(id:number, Ganho: GanhoModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Ganho, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
