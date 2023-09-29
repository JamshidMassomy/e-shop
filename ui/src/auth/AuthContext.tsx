import { createContext } from 'react';

export interface IAuthContext {
  login?: (data: any) => void;
  logout?: () => void;
  isLoggedIn?: () => boolean;
}

export const AuthContext = createContext<IAuthContext>({
  isLoggedIn: () => false,
  login: () => {},
  logout: () => {},
});
