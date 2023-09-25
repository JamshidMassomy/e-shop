import React from "react";
import { Navigate } from "react-router-dom";
import { useAuth } from "./useAuth";

const PrivateRoute: React.FC<any> = ({ children }) => {
  const { isLoggedIn } = useAuth();
  if (!isLoggedIn?.()) {
    return <Navigate to="/login" />;
  }
  return children;
};
export default PrivateRoute;
