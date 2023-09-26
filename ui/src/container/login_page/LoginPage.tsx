// react
import React, { memo, useEffect } from 'react';

// hooks
import { useAuth } from '../../auth/useAuth';

import { _fetch } from '../../api/api.config';

// styles
import './LoginPageStyles.scss';
import { GoogleLogin } from '@react-oauth/google';
import { LABELS } from '../../util/Constants';

export interface IUserData {
  name: string;
  given_name: string;
  family_name: string;
  email: string;
  picture: string;
}

const LoginPage = () => {
  const { login } = useAuth();
  const handleLoginFailer = () => {};

  useEffect(() => {
    clearCache();
  }, []);

  const clearCache = () => {
    localStorage.clear();
    document.cookie = '';
  };

  const handleLogin = (oauthResponse: any) => {
    login?.(oauthResponse);
  };

  return (
    <div className="wrapper">
      <div className="container">
        <div className="container-col-left">
          <div className="login-text">
            <h2>{LABELS.E_SHOPE}</h2>
            <span>{LABELS.LOGIN_ACCESS_LABEL}</span>
          </div>
        </div>
        <div className="container-col-right">
          <div className="login-form">
            <h2>{LABELS.LOGIN}</h2>
            <GoogleLogin onSuccess={handleLogin} onError={handleLoginFailer} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default memo(LoginPage);
