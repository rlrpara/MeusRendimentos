import React from 'react';
import Login from './pages/Login';
import LoginCadastro from './pages/LoginCadastro';

import GlobalStyles from './styles/global'

const App: React.FC = () => (
  <>
    <LoginCadastro />
    <GlobalStyles />
  </>
);

export default App;
