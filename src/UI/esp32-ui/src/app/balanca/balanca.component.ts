import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BalancaDTO } from '../shared/DTOs/BalancaDTO';
import { Paginacao } from '../shared/DTOs/Paginacao';
import { BalancaService } from '../shared/services/balanca.service';

@Component({
  selector: 'app-balanca',
  templateUrl: './balanca.component.html',
  styleUrls: ['./balanca.component.scss'],
})
export class BalancaComponent implements OnInit {
  public balancas: Paginacao<BalancaDTO>;

  constructor(
    private balancaService: BalancaService,
    private _location: Location,
    private snackBar: MatSnackBar
  ) {
    this.list();
  }

  list(): void {
    this.balancaService.list(0, 10, true, '').subscribe((balanca) => {
      this.balancas = balanca;
    });
  }

  ngOnInit(): void {}

  back(): void {
    this._location.back();
  }

  remove(id: any): void {
    this.balancaService.delete(id).subscribe(
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
