// react
import React from 'react';
import ReactDOM from 'react-dom/client';

// app
import './index.css';
import App from './App';

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

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
