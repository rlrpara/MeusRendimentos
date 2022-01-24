export class Categoria {
  Id: number = 0;
  descricao : string = "";
  icone : string = "";
  tipoId : number = 0;
  ativo : boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
