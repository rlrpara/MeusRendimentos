import React, { useCallback, useRef } from "react";
import { FiArrowLeft, FiAtSign, FiUser, FiFileText } from 'react-icons/fi';
import { FormHandles } from '@unform/core';
import { Form } from '@unform/web';
import * as Yup from 'yup';
import getValidationErrors from '../../Utils/getValidationErrors';

import { Container, Content, Background } from './styles'

import logoImg from '../../assets/logoImg.png';

import Button from '../../components/Button';
import Input from '../../components/Input';

const LoginCadastro: React.FC = () => {
  const formRef = useRef<FormHandles>(null);

  const handleSubmit = useCallback(async (data: object) => {
    try {
      formRef.current?.setErrors({})
      const schema = Yup.object().shape({
        nome: Yup.string().required('Nome obrigatório.'),
        email: Yup.string().required('E-Mail obrigatório.').email('Digite um E-Mail válido.'),
        senha: Yup.string().min(6, 'Senha mínimo 6 digitos.'),
        cpf: Yup.string().min(11, 'Senha mínimo 11 digitos'),
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
      <Background />
      <Content>
        <img src={logoImg} alt="Meus Rendimentos" />
        <Form ref={formRef} onSubmit={handleSubmit}>
          <h1>Faça seu Cadastro</h1>

          <Input name="nome" icon={FiUser} placeholder="Nome" />
          <Input name="email" icon={FiAtSign} placeholder="E-mail" />
          <Input name="senha" icon={FiUser} type="password" placeholder="Senha" />
          <Input name="cpf" icon={FiFileText} placeholder="CPF" />
          <Button type="submit">Cadastrar</Button>

        </Form>
        <a href="/"><FiArrowLeft /> Voltar para logon</a>
      </Content>
    </Container>
  )
};

export default LoginCadastro;