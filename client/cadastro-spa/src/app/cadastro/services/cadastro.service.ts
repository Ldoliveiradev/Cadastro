import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable } from 'rxjs';
import { Pessoa } from '../models/pessoa';
import { BaseService } from 'src/app/services/base.service';

@Injectable({
  providedIn: 'root',
})
export class CadastroService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  obterTodos(): Observable<Pessoa[]> {
    return this.http
      .get<Pessoa[]>(this.UrlService)
      .pipe(catchError(super.serviceError));
  }

  obterPorId(id: number): Observable<Pessoa> {
    return this.http
      .get<Pessoa>(this.UrlService + id)
      .pipe(catchError(super.serviceError));
  }

  criarCadastro(pessoa: Pessoa): Observable<Pessoa> {
    return this.http
      .post<Pessoa>(this.UrlService, pessoa)
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  atualizarCadastro(pessoa: Pessoa): Observable<Pessoa> {
    return this.http
      .put<Pessoa>(this.UrlService + pessoa.id, pessoa)
      .pipe(map(super.extractData), catchError(super.serviceError));
  }

  excluirCadastro(id: number): Observable<Pessoa> {
    return this.http
      .delete<Pessoa>(this.UrlService + id)
      .pipe(map(super.extractData), catchError(super.serviceError));
  }
}
