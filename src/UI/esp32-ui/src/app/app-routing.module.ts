import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'balanca',
    loadChildren: () =>
      import('./balanca/balanca.module').then((m) => m.BalancaModule),
  },
  {
    path: 'produto',
    loadChildren: () =>
      import('./produto/produto.module').then((m) => m.ProdutoModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
