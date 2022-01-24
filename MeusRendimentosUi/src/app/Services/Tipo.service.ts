import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tipo } from '../Models/Tipo';

@Injectable({
  providedIn: 'root'
})
export class TipoService {

  url: string = 'api/tipo';

constructor(private http: HttpClient) { }

PegarTodos(): Observable<Tipo[]>{
  return this.http.get<Tipo[]>(this.url);
}

}
