export class Cartao {
  id : number = 0;
  descricao : string = "";
  bandeira : string = "";
  numero : string = "";
  usuarioId : number = 0;
  ativo : boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
