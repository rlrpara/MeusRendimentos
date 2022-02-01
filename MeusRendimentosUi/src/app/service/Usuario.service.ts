import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UsuarioModel } from '../model/UsuarioModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  url = 'api/Usuario';

constructor(private http: HttpClient) { }

  ObterTodos(): Observable<UsuarioModel[]> {
    return this.http.get<UsuarioModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<UsuarioModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<UsuarioModel>(apiUrl);
  }

  Inserir(Usuario: UsuarioModel): Observable<any> {
    return this.http.post(this.url, Usuario, httpOptions);
  }

  Atualizar(id:number, Usuario: UsuarioModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Usuario, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
