// react
import React, { memo, useEffect, useState } from 'react';

// hooks
import './HeaderStyles.css';

// styles
import { useAuth } from '../../auth/useAuth';
import { LABELS } from '../../util/Constants';

const Header = () => {
  const { logout } = useAuth();
  const [name, setName] = useState<string>();

  const handleLogout = () => {
    logout?.();
  };

  useEffect(() => {
    fetchUserDetail();
  }, []);

  const fetchUserDetail = () => {
    const parsedUserData = JSON.parse(localStorage.getItem('user') as any);
    if (parsedUserData) {
      setName(parsedUserData?.name || parsedUserData?.email);
    }
  };

  return (
    <div className="header">
      <div className="username">
        {LABELS.WELCOME_MESSAGE} {name}
      </div>
      <button className="logout-button" onClick={handleLogout}>
        {LABELS.LOG_OUT}
      </button>
    </div>
  );
};

export default memo(Header);
