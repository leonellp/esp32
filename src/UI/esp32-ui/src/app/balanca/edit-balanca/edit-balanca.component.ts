import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Paginacao } from 'src/app/shared/DTOs/Paginacao';
import { ProdutoDTO } from 'src/app/shared/DTOs/ProdutoDTO';
import { BalancaService } from 'src/app/shared/services/balanca.service';
import { ProdutoService } from 'src/app/shared/services/produto.service';

@Component({
  selector: 'app-edit-balanca',
  templateUrl: './edit-balanca.component.html',
  styleUrls: ['./edit-balanca.component.scss'],
})
export class EditBalancaComponent implements OnInit {
  editMode = true;
  id = '';
  produtos: Paginacao<ProdutoDTO>;
  produtoSelected: ProdutoDTO;

  balancaForm: FormGroup;

  constructor(
    private activatedRoute: ActivatedRoute,
    private _location: Location,
    private formBuilder: FormBuilder,
    private produtoService: ProdutoService,
    private balancaService: BalancaService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {
    this.balancaForm = this.formBuilder.group({
      nome: ['', Validators.required],
      produtoId: [''],
    });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((data) => {
      if (data.id) {
        this.editMode = true;
        this.id = data.id;

        this.balancaService.getById(data.id).subscribe(
          (balanca) => {
            if (balanca) {
              this.balancaForm.controls['nome'].setValue(balanca.nome);
              this.balancaForm.controls['produtoId'].setValue(
                balanca.produtoId
              );

              if (balanca.produtoId) {
                this.produtoService
                  .getById(balanca.produtoId)
                  .subscribe((produto) => {
                    this.produtoSelected = produto;
                  });
              }
            }
          },
          () => {}
        );
      } else this.editMode = false;
    });

    this.produtoService.list(0, 100, true, '').subscribe(
      (_produtos) => {
        this.produtos = _produtos;
      },
      () => {
        this.produtos.count = 0;
      }
    );
  }

  back(): void {
    this._location.back();
  }

  selectedChanged(event: any): void {
    this.balancaForm.controls['produtoId'].setValue(event.value.idproduto);
  }

  save(): void {
    this.balancaForm.markAllAsTouched();
    console.log(this.balancaForm.value);

    if (this.id) {
      this.balancaService.update(this.balancaForm.value).subscribe(
        () => {
          this.snackBar.open('Balanca atulizada com sucesso!', '', {
            duration: 3000,
          });
        },
        () => {
          this.snackBar.open(
            'Erro ao atualizar Balanca, tente novamente mais tarde!',
            '',
            {
              duration: 3000,
            }
          );
        }
      );
    } else {
      this.balancaService.post(this.balancaForm.value).subscribe(
        (id) => {
          this.snackBar.open('Balanca criada com sucesso!', '', {
            duration: 3000,
          });

          this.router.navigate(['/balancas', id, 'edit']);
        },
        () => {
          this.snackBar.open(
            'Erro ao criar Balança, tente novamente mais tarde!',
            '',
            {
              duration: 3000,
            }
          );
        }
      );
    }
  }
}
