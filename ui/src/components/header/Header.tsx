// react
import React, { memo, useEffect, useRef, useState } from 'react';

// components
import { useAuth } from '../../auth/useAuth';
import { LABELS } from '../../util/Constants';
import Icon from '../icon/Icon';
import { Cart } from '../cart';
import LogoutButton from '../logout_button/LogoutButton';

// styles
import './HeaderStyles.scss';
import { useSelector } from 'react-redux';

const Header = () => {
  const { logout } = useAuth();
  const [name, setName] = useState<string>();
  const [isCartActive, setIsCartActive] = useState<boolean>(false);
  const selector = useSelector((state: any) => state?.item);

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

  const toggleCart = () => {
    setIsCartActive(!isCartActive);
  };

  return (
    <>
      <div className="header">
        <div className="header-left">
          <div className="username">
            {LABELS.WELCOME_MESSAGE} {name}
          </div>
        </div>

        <div className="header-top-buttons">
          <div className="shop-cart">
            <div className="shop-cart-btn">
              <button className="cart-icon" onClick={toggleCart}>
                <Icon icon="shopping-cart" />
                <span>{selector?.cart.length || 0}</span>
              </button>

              <div className={`shoping-cart`}>
                {isCartActive ? <Cart /> : null}
              </div>
            </div>
          </div>
          <LogoutButton onClick={handleLogout} />
        </div>
      </div>
    </>
  );
};

export default memo(Header);
