import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatTableModule } from '@angular/material/table';
import { BalancaComponent } from './balanca.component';
import { BalancaRoutingModule } from './balanca.routing';
import { EditBalancaComponent } from './edit-balanca/edit-balanca.component';

@NgModule({
  declarations: [BalancaComponent, EditBalancaComponent],
  imports: [
    CommonModule,
    BalancaRoutingModule,
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
  ],
})
export class BalancaModule {}
