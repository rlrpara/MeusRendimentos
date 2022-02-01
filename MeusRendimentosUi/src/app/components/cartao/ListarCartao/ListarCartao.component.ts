import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { CartaoService } from 'src/app/service/Cartao.service';

@Component({
  selector: 'app-ListarCartao',
  templateUrl: './ListarCartao.component.html',
  styleUrls: ['./ListarCartao.component.css']
})
export class ListarCartaoComponent implements OnInit {

  cartoes = new MatTableDataSource<any>();
  displayedColumns: string[] = [];

  constructor(private cartaoService: CartaoService) { }

  ngOnInit() {
    // this.cartaoService.ObterTodos().subscribe((resultado) => {
    //   this.cartoes.data = resultado;
    // });

    // this.displayedColumns = this.ExibirColunas();
  }

  ExibirColunas(): string[] {
    return ['nome', 'icone', 'tipo', 'acoes'];
  }

}
