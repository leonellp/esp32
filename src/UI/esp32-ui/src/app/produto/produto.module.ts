import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { EditProdutoComponent } from './edit-produto/edit-produto.component';
import { HistoricoProdutoComponent } from './historico-produto/historico-produto.component';
import { ProdutoComponent } from './produto.component';
import { ProdutoRoutingModule } from './produto.routing';

@NgModule({
  declarations: [
    ProdutoComponent,
    EditProdutoComponent,
    HistoricoProdutoComponent,
  ],
  imports: [
    CommonModule,
    ProdutoRoutingModule,
    FormsModule,
    ReactiveFormsModule,

    FlexLayoutModule,

    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatDividerModule,
    MatInputModule,
    MatSnackBarModule,
    MatSlideToggleModule,
    MatSelectModule,
    MatTableModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
  ],
})
export class ProdutoModule {}
