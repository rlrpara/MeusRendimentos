import React from 'react';
import Login from './pages/Login';

import { AuthProvider } from './Context/AuthContext';

import GlobalStyles from './styles/global'

const App: React.FC = () => (
  <>
    <AuthProvider>
      <Login />
    </AuthProvider>

    <GlobalStyles />
  </>
);

export default App;
