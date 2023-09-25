import React from 'react';

// redux
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router';
// import { showNotification } from '../action/pageAction';
import { _fetch } from '../api/api.config';

// context
import { AuthContext } from './AuthContext';

// hook
import { useLocalStorage } from './useLocalStorage';

export interface IUser {
  email?: string;
}

export interface ILogin extends IUser {
  username: string;
  apiKey: string;
}

export const AuthProvider = ({ children }: any) => {
  const [user, setUser] = useLocalStorage('user', null);
  const [apiKey, setApikey] = useLocalStorage('apikey', null);

  const navigate = useNavigate();
  const dispatch: any = useDispatch();

  const isLoggedIn = () => {
    return apiKey !== null && user !== null;
  };

  const handleSuccessfulLogin = () => {
    navigate('/news');
  };

  const login = async (loginData: ILogin) => {
    await _fetch('login', loginData)
      .then(() => {
        setApikey(loginData?.apiKey || null);
        setUser(loginData?.username);
        handleSuccessfulLogin();
      })
      .catch(() => {
        // dispatch(showNotification('Incorrect username or API key')); // faild login
      });
  };

  const logout = () => {
    localStorage.clear();
    navigate('/login');
    setUser(null);
  };

  const value: any = {
    user,
    login,
    logout,
    isLoggedIn,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
