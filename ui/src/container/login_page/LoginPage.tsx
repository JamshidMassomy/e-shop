import React, { memo } from 'react';
import GoogleLoginButton from '../../components/google_button/GoogleButton';

import './LoginPageStyles.css'

const LoginPage: React.FC = () => {
  const handleSuccess = (response: any) => {
    // Handle successful login (e.g., send token to your server)
    console.log('Google login success', response);
  };

  const handleFailure = (error: any) => {
    // Handle login failure
    console.error('Google login failed', error);
  };

  return (
    <div className="login-page">
      <h1>Login</h1>
      <GoogleLoginButton onSuccess={handleSuccess} onFailure={handleFailure} />
    </div>
  );
};

export default memo(LoginPage);
