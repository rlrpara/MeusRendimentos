import React from "react";
import { FiArrowLeft, FiAtSign, FiUser, FiFileText } from 'react-icons/fi';

import { Container, Content, Background } from './styles'

import logoImg from '../../assets/logoImg.png';

import Button from '../../components/Button';
import Input from '../../components/Input';

const LoginCadastro: React.FC = () => (
  <Container>
    <Background />
    <Content>
      <img src={logoImg} alt="Meus Rendimentos" />
      <form>
        <h1>Faça seu Cadastro</h1>

        <Input name="nome" icon={FiUser} placeholder="Nome" />

        <Input name="email" icon={FiAtSign} placeholder="E-mail" />

        <Input name="senha" icon={FiUser} type="password" placeholder="Senha" />

        <Input name="cpf" icon={FiFileText} placeholder="CPF" />

        <Button type="submit">Cadastrar</Button>

      </form>
      <a href="/"><FiArrowLeft /> Voltar para logon</a>
    </Content>

  </Container>
);

export default LoginCadastro;