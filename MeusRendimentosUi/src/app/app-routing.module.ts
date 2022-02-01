import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarCartaoComponent } from './components/cartao/ListarCartao/ListarCartao.component';
import { ListarCategoriaComponent } from './components/categoria/ListarCategoria/ListarCategoria.component';


const routes: Routes = [
  { path: '', component: ListarCategoriaComponent },
  { path: 'categorias', component: ListarCategoriaComponent },
  { path: 'cartoes', component: ListarCartaoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
