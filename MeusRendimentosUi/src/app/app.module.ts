import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListarCategoriaComponent } from './components/categoria/ListarCategoria/ListarCategoria.component';

import { HttpClientModule }  from '@angular/common/http';
import { CartaoService } from './service/Cartao.service';
import { MatTableModule } from '@angular/material/table';
import { CategoriaService } from './service/Categoria.service';
import { DespesaService } from './service/Despesa.service';
import { GanhoService } from './service/Ganho.service';
import { MesService } from './service/Mes.service';
import { TipoService } from './service/Tipo.service';
import { UsuarioService } from './service/Usuario.service';

@NgModule({
  declarations: [ AppComponent, ListarCategoriaComponent ],
  imports: [ BrowserModule, AppRoutingModule, BrowserAnimationsModule, MatTableModule ],
  providers: [ HttpClientModule, CartaoService, CategoriaService, DespesaService, GanhoService, MesService, TipoService, UsuarioService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
