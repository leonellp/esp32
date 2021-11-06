import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { BalancaDTO } from 'src/app/shared/DTOs/BalancaDTO';
import { Paginacao } from 'src/app/shared/DTOs/Paginacao';
import { BalancaService } from 'src/app/shared/services/balanca.service';
import { ProdutoService } from 'src/app/shared/services/produto.service';

@Component({
  selector: 'app-edit-produto',
  templateUrl: './edit-produto.component.html',
  styleUrls: ['./edit-produto.component.scss'],
})
export class EditProdutoComponent implements OnInit {
  editMode = true;
  id = '';
  balancas: Paginacao<BalancaDTO>;
  balanca: BalancaDTO;
  balancaSelected = false;

  productForm: FormGroup;

  constructor(
    private activatedRoute: ActivatedRoute,
    private _location: Location,
    private formBuilder: FormBuilder,
    private produtoService: ProdutoService,
    private balancaService: BalancaService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {
    this.productForm = this.formBuilder.group({
      nome: ['', Validators.required],
      marca: ['', Validators.required],
      peso: ['', Validators.required],
      inativo: [''],
      balanca: [''],
    });
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((data) => {
      if (data.id) {
        this.editMode = true;
        this.id = data.id;

        this.produtoService.getById(data.id).subscribe(
          (produto) => {
            if (produto) {
              this.productForm.controls['nome'].setValue(produto.nome);
              this.productForm.controls['marca'].setValue(produto.marca);
              this.productForm.controls['peso'].setValue(produto.peso);
              this.productForm.controls['balanca'].setValue(
                produto.balanca[0]?.nome
              );

              if (produto.inativo)
                this.productForm.controls['inativo'].setValue(true);
              else this.productForm.controls['inativo'].setValue(false);
            }
          },
          () => {}
        );
      } else this.editMode = false;
    });

    this.balancaService.list(0, 100, false, '').subscribe(
      (_balancas) => {
        this.balancas = _balancas;
      },
      () => {
        this.balancas.count = 0;
      }
    );
  }

  back(): void {
    this._location.back();
  }

  selectedChanged(event: any): void {
    this.balanca = event.value;
    this.balanca.produtoId = this.id;
    this.balancaSelected = true;
    this.productForm.markAllAsTouched();
  }

  save(): void {
    this.productForm.markAllAsTouched();
    if (this.id) {
      this.produtoService.update(this.productForm.value).subscribe(
        () => {
          this.snackBar.open('Produto atulizado com sucesso!', '', {
            duration: 3000,
          });
        },
        () => {
          this.snackBar.open(
            'Erro ao atualizar produto, tente novamente mais tarde!',
            '',
            {
              duration: 3000,
            }
          );
        }
      );
    } else {
      this.produtoService.post(this.productForm.value).subscribe(
        (id) => {
          this.snackBar.open('Produto criado com sucesso!', '', {
            duration: 3000,
          });

          this.router.navigate(['/produtos', id, 'edit']);
        },
        () => {
          this.snackBar.open(
            'Erro ao criar produto, tente novamente mais tarde!',
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
