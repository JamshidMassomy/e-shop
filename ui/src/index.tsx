// react
import React from 'react';
import ReactDOM from 'react-dom/client';

// app
import './index.scss';

import reportWebVitals from './reportWebVitals';

// redux
import { Provider } from 'react-redux';
import store from './store/store';

// router
import Router from './router';
import { BrowserRouter } from 'react-router-dom';

// oauth
import { GoogleOAuthProvider } from '@react-oauth/google';
import { AuthProvider } from './auth/AuthProvider';

import { OAUTH_CLIENT_ID } from './util/Constants';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <Provider store={store}>
    <GoogleOAuthProvider clientId={OAUTH_CLIENT_ID}>
      <BrowserRouter>
        <AuthProvider>
          <Router />
        </AuthProvider>
      </BrowserRouter>
    </GoogleOAuthProvider>
  </Provider>
);
reportWebVitals();
