import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BalancaComponent } from './balanca.component';

const routes: Routes = [
  {
    path: '',
    component: BalancaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BalancaRoutingModule {}
