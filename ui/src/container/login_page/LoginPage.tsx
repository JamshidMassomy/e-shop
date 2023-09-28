// react
import React, { memo, useEffect } from 'react';

// hooks
import { useAuth } from '../../auth/useAuth';

import { _fetch } from '../../api/api.config';

// styles
import './LoginPageStyles.scss';
import { GoogleLogin } from '@react-oauth/google';
import { LABELS } from '../../util/Constants';
import toast, { Toaster } from 'react-hot-toast';
import ReactErrorBoundary from '../../components/error_boundry/ReactErrorBoundry';

export interface IUserData {
  name: string;
  given_name: string;
  family_name: string;
  email: string;
  picture: string;
}

const LoginPage = () => {
  const { login } = useAuth();

  const handleLoginFailer = () => {
    toast('Unauthorized or Login failed');
  };

  useEffect(() => {
    clearCache();
  }, []);

  const clearCache = () => {
    localStorage.clear();
  };

  const handleLogin = (oauthResponse: any) => {
    login?.(oauthResponse);
  };

  return (
    <>
      <Toaster position="top-right"></Toaster>
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
              <div className="login-form-btn">
                <GoogleLogin
                  onSuccess={handleLogin}
                  onError={handleLoginFailer}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default memo(LoginPage);
