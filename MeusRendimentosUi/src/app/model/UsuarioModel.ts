export class UsuarioModel {
  codigo: number = 0;
  nome: string = '';
  email: string = '';
  senha: string = '';
  cpf: string = '';
  ativo: boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
