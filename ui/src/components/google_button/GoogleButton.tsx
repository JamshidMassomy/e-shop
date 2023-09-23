import React from 'react';


interface GoogleLoginButtonProps {
  onSuccess: (response: any) => void;
  onFailure: (error: any) => void;
}

const GoogleLoginButton: React.FC<GoogleLoginButtonProps> = ({ onSuccess, onFailure }) => {
  const clientId = 'YOUR_GOOGLE_CLIENT_ID';

  return (
    <button>Login with google</button>
  );
};

export default GoogleLoginButton;