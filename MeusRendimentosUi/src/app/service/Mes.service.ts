import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MesModel } from '../model/MesModel';

const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class MesService {

  url = 'api/Mes';

constructor(private http: HttpClient) { }

  ObterTodos(): Observable<MesModel[]> {
    return this.http.get<MesModel[]>(this.url);
  }

  ObterPorId(id: number): Observable<MesModel> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.get<MesModel>(apiUrl);
  }

  Inserir(Mes: MesModel): Observable<any> {
    return this.http.post(this.url, Mes, httpOptions);
  }

  Atualizar(id:number, Mes: MesModel): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.post(apiUrl, Mes, httpOptions);
  }

  Excluir(id: number): Observable<any> {
    const apiUrl = `${this.url}/${id}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
