import React from 'react';


interface GoogleLoginButtonProps {
  onSuccess: (response: any) => void;
  onFailure: (error: any) => void;
  onClick: () => Promise<void>;
}

const GoogleLoginButton: React.FC<GoogleLoginButtonProps> = ({ onSuccess, onFailure, onClick }) => {
  const clientId = 'YOUR_GOOGLE_CLIENT_ID';

  return (
    <button onClick={onClick}>Login with google</button>
  );
};

export default GoogleLoginButton;