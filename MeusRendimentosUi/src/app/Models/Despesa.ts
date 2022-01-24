export class Despesa {
  id: number = 0;
  descricao : string = "";
  cartaoId : number = 0;
  categoriaId : number = 0;
  valor : number = 0;
  dia : number = 0;
  mesId : number = 0;
  ano : number = 0;
  usuarioId : number = 0;
  ativo : boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
