import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarCategoriaComponent } from './components/categoria/ListarCategoria/ListarCategoria.component';

const routes: Routes = [
  { path: 'categoria/listarcategoria', component: ListarCategoriaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
