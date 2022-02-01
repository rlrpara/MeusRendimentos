export class CartaoModel {
  codigo: number = 0;
  descricao: string = '';
  bandeira: string = '';
  numero: string = '';
  limite : number = 0;
  usuarioId: number = 0;
  ativo: boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
