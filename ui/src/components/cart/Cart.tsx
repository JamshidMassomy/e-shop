// react
import React, { memo, useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

// buttons
import { removeCartAction } from '../../action/cartAction';
import { IItem } from '../../types';

// styles
import './CartStyles.scss';
import Icon from '../icon/Icon';

const Cart = () => {
  const itemSelector = useSelector((state: any) => state?.item);
  const [data, setData] = useState(itemSelector);
  const dispatcher: any = useDispatch();

  useEffect(() => {
    setData(itemSelector);
  }, [itemSelector]);

  const handleRemoveItem = (item: IItem) => {
    dispatcher(removeCartAction(item));
  };

  return (
    <>
      <div className="shopping-cart">
        <h3>Shopping Cart</h3>
        {itemSelector?.cart.length === 0 ? (
          <p>Your cart is empty.</p>
        ) : (
          <ul>
            {data?.cart.map((cartItem, index) => (
              <li key={index}>
                <div className="item-cart-li">
                  <span>{cartItem?.name}</span>
                  <span>{cartItem?.quantity}</span>
                </div>
                <Icon
                  icon="delete-icon"
                  onClick={() => handleRemoveItem(cartItem)}
                ></Icon>
              </li>
            ))}
          </ul>
        )}
      </div>
    </>
  );
};

export default memo(Cart);
