import React from "react";
import { FiLogIn, FiMail, FiLock } from 'react-icons/fi';

import { Container, Content, Background } from './styles'

import logoImg from '../../assets/logoImg.png';

import Button from '../../components/Button';
import Input from '../../components/Input';

const Login: React.FC = () => (
  <Container>
    <Content>
      <img src={logoImg} alt="Meus Rendimentos" />
      <form>
        <h1>Faça seu logon</h1>

        <Input name="email" icon={FiMail} placeholder="E-mail" />

        <Input name="senha" icon={FiLock} type="password" placeholder="Senha" />

        <Button type="submit">Entrar</Button>

        <a href="/">Esqueci minha senha</a>
      </form>
      <a href="/"><FiLogIn /> Criar conta</a>
    </Content>

    <Background />
  </Container>
);

export default Login;