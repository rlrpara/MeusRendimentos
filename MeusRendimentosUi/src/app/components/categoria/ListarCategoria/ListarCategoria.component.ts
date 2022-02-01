import { Component, OnInit } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';

import { CategoriaService } from '../../../service/Categoria.service';

@Component({
  selector: 'app-ListarCategoria',
  templateUrl: './ListarCategoria.component.html',
  styleUrls: ['./ListarCategoria.component.css']
})
export class ListarCategoriaComponent implements OnInit {

  categorias = new MatTableDataSource<any>();
  displayedColumns: string[] | undefined;

  constructor(private categoriaService: CategoriaService) { }

  ngOnInit() {
    this.categoriaService.ObterTodos().subscribe(resultado => {
      this.categorias.data = resultado;
    });

    this.displayedColumns = this.ExibirColunas();
  }

  ExibirColunas(): string[] {
    return ['codigo', 'descricao', 'icone', 'tipoId', 'acoes'];
  }
}
