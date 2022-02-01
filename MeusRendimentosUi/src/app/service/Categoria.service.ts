import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriaModel } from '../model/CategoriaModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {

  url = 'http://localhost:63498/api/categoria';

  constructor(private http: HttpClient) { }

  ObterTodos(): Observable<CategoriaModel[]> {
    return this.http.get<CategoriaModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<CategoriaModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<CategoriaModel>(apiUrl);
  }

  Inserir(Categoria: CategoriaModel): Observable<any> {
    return this.http.post(this.url, Categoria, httpOptions);
  }

  Atualizar(id:number, Categoria: CategoriaModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Categoria, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }

}
