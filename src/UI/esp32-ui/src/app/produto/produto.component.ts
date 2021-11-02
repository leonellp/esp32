import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Paginacao } from '../shared/DTOs/Paginacao';
import { ProdutoDTO } from '../shared/DTOs/ProdutoDTO';
import { ProdutoService } from '../shared/services/produto.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.scss'],
})
export class ProdutoComponent implements OnInit {
  produtos: Paginacao<ProdutoDTO>;

  constructor(
    private _location: Location,
    private produtoService: ProdutoService,
    private snackBar: MatSnackBar
  ) {
    this.list();
  }

  ngOnInit(): void {}

  back(): void {
    this._location.back();
  }

  list(): void {
    this.produtoService.list(0, 5, true, '').subscribe((produtos) => {
      this.produtos = produtos;
    });
  }

  remove(id: any): void {
    this.produtoService.delete(id).subscribe(
      () => {
        this.snackBar.open('Produto deletado com sucesso!', '', {
          duration: 3000,
        });
        this.list();
      },
      () => {
        this.snackBar.open(
          'Erro ao deletar produto, tente novamente mais tarde!',
          '',
          {
            duration: 3000,
          }
        );
      }
    );
  }
}
