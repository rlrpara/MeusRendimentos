import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ListarCategoriaComponent } from './components/categoria/ListarCategoria/ListarCategoria.component';

import { HttpClientModule }  from '@angular/common/http';
import { CartaoService } from './service/Cartao.service';

@NgModule({
  declarations: [
    AppComponent,
    ListarCategoriaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [
    HttpClientModule,
    CartaoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
