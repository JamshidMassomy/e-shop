import { createContext } from 'react';
// import { ILogin, IUser } from './AuthProvider';

export interface IAuthContext {
  // user?: IUser | null;
  login?: (data: any) => void;
  logout?: () => void;
  isLoggedIn?: () => boolean;
}

export const AuthContext = createContext<IAuthContext>({
  // user: null,
  isLoggedIn: () => false,
  login: () => {},
  logout: () => {},
});
