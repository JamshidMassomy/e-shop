import React, { memo, useState } from 'react';
import './LoginPageStyles.css';
import { _fetch } from '../../api/api.config';
import { GoogleLogin } from '@react-oauth/google';

import jwtDecode from 'jwt-decode';

export interface IUserData {
  name: string;
  given_name: string;
  family_name: string;
  email: string;
  picture: string;
}

const LoginPage = () => {
  const [userData, setUserData] = useState<any>(null);

  const responseGoogle = (response: any) => {
    const userData = jwtDecode(response?.credential);
    if (userData) {
      setUserData(userData);
    }
    const options = {
      method: 'POST',
      body: { tokenId: response?.credential },
    };

    _fetch('/Auth/authenticate-google', options).then((data) => {
      console.log('auth-data', data);
    });

    console.log('response', response);
  };

  return (
    <div className="login-container">
      {userData ? (
        <div>
          <h2>Welcome, {userData?.name}</h2>
          <p>Email: {userData?.email}</p>
          <button onClick={() => setUserData(null)}>Logout</button>
        </div>
      ) : (
        <GoogleLogin
          onSuccess={responseGoogle}
          onError={responseGoogle}
        ></GoogleLogin>
      )}
    </div>
  );
};

export default LoginPage;
