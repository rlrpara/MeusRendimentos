import React, { createContext, useCallback, useState } from 'react';
import api from '../Services/api';

import Api from '../Services/api';

interface LoginCredentials {
  email: string;
  senha: string;
}

interface AuthContextData {
  usuario: object;
  logIn(credentials: LoginCredentials): Promise<void>;
}

interface AuthState {
  token: string;
  usuario: object;
}

const AuthContext = createContext<AuthContextData>({} as AuthContextData);

const AuthProvider: React.FC = ({ children }) => {
  const [ data, setData] = useState<AuthState>(() => {
    const token = localStorage.getItem('@MeusRendimentos:token');
    const usuario = localStorage.getItem('@MeusRendimentos:usuario');

    if(token && usuario) {
      return { token, usuario: JSON.parse(usuario) };
    }

    return {} as AuthState;
  })

  const logIn = useCallback( async({ email, senha }) => {
    const response = await Api.post('api/login/authenticate', {
      email,
      senha
    })

    const { token, usuario } = response.data;

    localStorage.setItem('@MeusRendimentos:token', token);
    localStorage.setItem('@MeusRendimentos:usuario', JSON.stringify(usuario));

    setData({ token, usuario });
  }, []);

  return (
    <AuthContext.Provider value={{ usuario: data.usuario, logIn }}>
      {children}
    </AuthContext.Provider>
  );
};

export { AuthContext, AuthProvider };