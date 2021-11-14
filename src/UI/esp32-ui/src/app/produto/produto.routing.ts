import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditProdutoComponent } from './edit-produto/edit-produto.component';
import { HistoricoProdutoComponent } from './historico-produto/historico-produto.component';
import { ProdutoComponent } from './produto.component';

const routes: Routes = [
  {
    path: '',
    component: ProdutoComponent,
  },
  {
    path: 'new',
    component: EditProdutoComponent,
  },
  {
    path: ':id/edit',
    component: EditProdutoComponent,
  },
  {
    path: ':id/historico',
    component: HistoricoProdutoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProdutoRoutingModule {}
