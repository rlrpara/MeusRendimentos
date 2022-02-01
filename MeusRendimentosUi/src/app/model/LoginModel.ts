export class LoginModel {
  codigo: number = 0;
  email : string = '';
  senha : string = '';
  ativo: boolean = true;
  dataCadastro : Date = new Date();
  dataAtualizacao : Date = new Date();
}
