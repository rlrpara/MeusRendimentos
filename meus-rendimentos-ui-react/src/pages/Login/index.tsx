import React, {useRef, useCallback } from "react";
import { FiLogIn, FiMail, FiLock } from 'react-icons/fi';
import { Form } from '@unform/web';
import { FormHandles } from '@unform/core';
import * as Yup from 'yup';

import { Container, Content, Background } from './styles'

import logoImg from '../../assets/logoImg.png';

import getValidationErrors from '../../Utils/getValidationErrors';
import Button from '../../components/Button';
import Input from '../../components/Input';

const Login: React.FC = () => {

  const formRef = useRef<FormHandles>(null);

  const handleSubmit = useCallback(async (data: object) => {
    try {
      formRef.current?.setErrors({})
      const schema = Yup.object().shape({
        email: Yup.string().required('E-Mail obrigatório.').email('Digite um E-Mail válido.'),
        senha: Yup.string().required('Senha obrigatória.'),
      });

      await schema.validate(data, {
        abortEarly: false,
      });
    } catch (err: any) {
      console.log(err);

      const errors = getValidationErrors(err);

      formRef.current?.setErrors(errors);
    }
  }, [])
  
  return (  
    <Container>
      <Content>
        <img src={logoImg} alt="Meus Rendimentos" />
        <Form ref={formRef} onSubmit={handleSubmit}>
          <h1>Faça seu logon</h1>

          <Input name="email" icon={FiMail} placeholder="E-mail" />

          <Input name="senha" icon={FiLock} type="password" placeholder="Senha" />

          <Button type="submit">Entrar</Button>

          <a href="/">Esqueci minha senha</a>
        </Form>
        <a href="/"><FiLogIn /> Criar conta</a>
      </Content>

      <Background />
    </Container>
  );
}

export default Login;