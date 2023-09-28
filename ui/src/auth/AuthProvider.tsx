import React from 'react';

// redux
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router';
import toast, { Toaster } from 'react-hot-toast';

// import { showNotification } from '../action/pageAction';
import { _fetch } from '../api/api.config';

// context
import { AuthContext } from './AuthContext';

// hook
import { useLocalStorage } from './useLocalStorage';
import jwtDecode from 'jwt-decode';
import { IToken } from '../types';

export const AuthProvider = ({ children }: any) => {
  const [user, setUser] = useLocalStorage('user', null);

  const navigate = useNavigate();
  const dispatch: any = useDispatch();

  const isLoggedIn = () => {
    return localStorage.getItem('token') !== null;
  };

  const handleSuccessfulLogin = () => {
    navigate('/');
  };

  const login = async (oauthResponse: any) => {
    const userData: any = jwtDecode(oauthResponse?.credential);
    const options = {
      method: 'POST',
      body: { tokenId: oauthResponse?.credential },
    };

    _fetch('/Auth/authenticate-google', options)
      .then((data: IToken | any) => {
        localStorage.setItem('token', data?.token);
        localStorage.setItem('user', JSON.stringify(userData));
        handleSuccessfulLogin();
        toast('Logged in');
      })
      .catch(() => {
        toast('Unable to authenticate or Invalid login');
      });
  };

  const logout = () => {
    localStorage.clear();
    navigate('/login');
  };

  const value: any = {
    //  user,
    login,
    logout,
    isLoggedIn,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
