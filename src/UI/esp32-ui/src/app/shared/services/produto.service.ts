import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Paginacao } from '../DTOs/Paginacao';
import { ProdutoDTO } from '../DTOs/ProdutoDTO';
import { ProdutoInsertDTO } from '../DTOs/ProdutoInsertDTO';

@Injectable({
  providedIn: 'root',
})
export class ProdutoService {
  private readonly API = `${environment.API}/produto`;

  constructor(private http: HttpClient) {}

  list(
    skip: number,
    pageSize: number,
    count: boolean,
    pesquisa?: string
  ): Observable<Paginacao<ProdutoDTO>> {
    return this.http.get<Paginacao<ProdutoDTO>>(
      this.API +
        '?skip=' +
        skip +
        '&pageSize=' +
        pageSize +
        '&count=' +
        count +
        '&pesquisa=' +
        pesquisa
    );
  }

  getById(id: string): Observable<ProdutoDTO> {
    return this.http.get<ProdutoDTO>(`${this.API}/${id}`);
  }

  delete(id: string) {
    return this.http.delete(`${this.API}/${id}`);
  }

  post(produto: ProdutoInsertDTO): Observable<any> {
    return this.http.post<any>(this.API, produto);
  }

  update(produto: ProdutoDTO) {
    return this.http.put(`${this.API}/${produto.idproduto}`, produto);
  }
}
