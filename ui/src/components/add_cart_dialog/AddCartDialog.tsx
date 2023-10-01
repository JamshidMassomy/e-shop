/// react
import React, { memo, useEffect, useState } from 'react';

// component
import Input from '../input/Input';

// redux
import { useDispatch } from 'react-redux';
import { addCartAction } from '../../action/cartAction';
import toast, { Toaster } from 'react-hot-toast';
import Dialog from '../dialog/Dialog';
import { IItem } from '../../types';

const AddCartDialog: React.FC<any> = ({ isOpen, item, handleClose }: any) => {
  const [isActive, setIsActive] = useState<boolean>();
  const [quantity, setQuantity] = useState<number>();
  const [cartItem, setCartItem] = useState<IItem>();

  const dispatcher = useDispatch();

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  useEffect(() => {
    setCartItem(item);
  }, [item]);

  const handleChange = (event: any) => {
    const value = event.target.value;
    if (value) {
      setQuantity(value);
    }
  };

  const handleAddToCart = () => {
    item.quantity = quantity;
    dispatcher(addCartAction(item) as any);
    toast(`Added item to the cart`);
    reset();
  };

  const reset = () => {
    setQuantity(undefined);
    handleClose();
  };

  return (
    <>
      <Toaster position="top-right" />
      <Dialog isActive={isActive} handleClose={handleClose}>
        <div className="dialog-header">
          <h2>Add To Cart</h2>
        </div>
        <div className="dialog-body">
          <div className="dialog-body-row">
            <label>Item Name</label>
            <Input
              disabled={'disabled'}
              value={cartItem?.name}
              name="name"
              onChange={handleChange}
            />
          </div>
          <div className="dialog-body-row">
            <label>Quantity</label>
            <Input
              type={'number'}
              value={quantity}
              name="quantity"
              onChange={handleChange}
            />
          </div>
        </div>
        <div className="dialog-footer">
          <button className="cancel-button" onClick={handleClose}>
            Cancel
          </button>
          <button className="add-button" onClick={handleAddToCart}>
            Add to Cart
          </button>
        </div>
      </Dialog>
    </>
  );
};

export default memo(AddCartDialog);
