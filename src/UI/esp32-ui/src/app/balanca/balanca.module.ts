import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BalancaComponent } from './balanca.component';
import { BalancaRoutingModule } from './balanca.routing';

@NgModule({
  declarations: [BalancaComponent],
  imports: [CommonModule, BalancaRoutingModule],
})
export class BalancaModule {}
