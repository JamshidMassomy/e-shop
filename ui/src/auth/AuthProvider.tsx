// redux
import { useNavigate } from 'react-router';
import toast, { Toaster } from 'react-hot-toast';
import { _fetch } from '../api/api.config';

// context
import { AuthContext } from './AuthContext';

// hook
import jwtDecode from 'jwt-decode';
import { IToken } from '../types';
import { ERROR_LABLES } from '../util/Constants';

export const AuthProvider = ({ children }: any) => {
  const navigate = useNavigate();
  const isLoggedIn = () => {
    const token = localStorage.getItem('token');
    if (token) {
      try {
        const decodedToken: any = jwtDecode(token);
        const currentTime = Math.floor(Date.now() / 1000);
        if (decodedToken.exp > currentTime) {
          return true;
        }
      } catch (error) {
        return false;
      }
    }

    return false;
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
        toast(ERROR_LABLES.FAILED_LOGIN);
      });
  };

  const logout = () => {
    localStorage.clear();
    navigate('/login');
  };

  const value: any = {
    login,
    logout,
    isLoggedIn,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
