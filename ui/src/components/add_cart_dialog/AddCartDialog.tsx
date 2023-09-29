/// react
import React, { useEffect, useState } from 'react';

// component
import Input from '../input/Input';

// redux
import { useDispatch, useSelector } from 'react-redux';
import { addCartAction } from '../../action/cartAction';
import toast, { Toaster } from 'react-hot-toast';

const AddCartDialog: React.FC<any> = ({ isOpen, item, handleClose }: any) => {
  const [isActive, setIsActive] = useState<boolean>(isOpen);
  const dispatcher = useDispatch();
  const selector: any = useSelector((state: any) => state);

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  const handleChange = (event: any) => {};

  const handleAddToCart = () => {
    dispatcher(addCartAction(item) as any);
    toast(`Added ${item?.name} to the cart`);
  };

  return (
    <>
      <Toaster position="top-right" />
      <div className={`item-dialog ${isActive ? 'open' : ''}`}>
        <div className="dialog-content">
          <div className="dialog-header">
            <h2>Add To Cart</h2>
          </div>
          <div className="dialog-body">
            <div className="dialog-body-row">
              <label>Item Name</label>
              <Input value={item?.name} name="name" onChange={handleChange} />
            </div>
            <div className="dialog-body-row">
              <label>Quantity</label>
              <Input name="quantity" onChange={handleChange} />
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
        </div>
      </div>
    </>
  );
};

export default AddCartDialog;
