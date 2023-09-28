import React, { memo, useEffect, useState } from 'react';
import './CartStyles.scss';
import { useSelector } from 'react-redux';
import { IItem } from '../../types';
import IconButton from '../icon_button/IconButton';

const Cart = () => {
  const selector = useSelector((state: any) => state?.item);
  const [data, setData] = useState(selector);

  useEffect(() => {
    setData(selector);
    console.log(data);
  }, [selector]);

  const handleRemoveItem = (item: IItem) => {};
  console.log('seelctr', { data, id: data });

  return (
    <>
      <div className="shopping-cart">
        <h3>Shopping Cart</h3>
        {selector?.cart.length === 0 ? (
          <p>Your cart is empty.</p>
        ) : (
          <ul>
            {data.cart.map((cartItem, index) => (
              <li key={index}>
                <span>{cartItem.item.name}</span>
                <span>{cartItem.item.quantity}</span>
                <IconButton
                  icon="delete-icon"
                  onClick={() => handleRemoveItem(cartItem.item)}
                />
              </li>
            ))}
          </ul>
        )}
      </div>
    </>
  );
};

export default memo(Cart);
