import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BalancaComponent } from './balanca.component';
import { EditBalancaComponent } from './edit-balanca/edit-balanca.component';

const routes: Routes = [
  {
    path: '',
    component: BalancaComponent,
  },
  {
    path: 'new',
    component: EditBalancaComponent,
  },
  {
    path: ':id/edit',
    component: EditBalancaComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BalancaRoutingModule {}
