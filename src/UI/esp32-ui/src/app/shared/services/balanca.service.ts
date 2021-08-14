import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BalancaDTO } from '../DTOs/BalancaDTO';
import { Paginacao } from '../DTOs/Paginacao';

@Injectable({
  providedIn: 'root'
})
export class BalancaService {
  private readonly API = `${environment.API}/balanca`

  constructor(private http: HttpClient) { }

  list(skip: number, pageSize: number, count: boolean, pesquisa?: string): Observable<Paginacao<BalancaDTO>> {
    return this.http.get<Paginacao<BalancaDTO>>(
      this.API +
      "?skip=" + skip +
      "&pageSize=" + pageSize +
      "&count=" + count +
      "&pesquisa=" + pesquisa
    );
  }

  getById(id: string): Observable<BalancaDTO> {
    return this.http.get<BalancaDTO>(`${this.API}/${id}`);
  }

  delete(id: string) {
    return this.http.delete(`${this.API}/${id}`);
  }

  post(balanca: BalancaDTO): Observable<string> {
    return this.http.post<string>(this.API, balanca);
  }

  update(balanca: BalancaDTO) {
    return this.http.put(`${this.API}/${balanca.Idbalanca}`, balanca);
  }
}
