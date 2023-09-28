// react
import React, { memo, useEffect, useState } from 'react';

// types
import Input from '../input/Input';
import { IItem, IUpdateItem } from '../../types';
import { _fetch } from '../../api/api.config';

const UpdateItemDialog = (props: IUpdateItem) => {
  const { isOpen, oldItem, item } = props;
  const [isActive, setIsActive] = useState<boolean>(isOpen);

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  const [newItem, setNewItem] = useState<any>(item);

  const handleChange = (event: any) => {
    const { name, value } = event.target;
    setNewItem((prevData) => ({
      ...prevData,
      [name]: value,
    }));
    console.log('change', { newItem, item });
  };

  const handleClose = () => {
    setIsActive(false);
  };

  return (
    <div className={`item-dialog ${isActive ? 'open' : ''}`}>
      <div className="dialog-content">
        <div className="dialog-header">
          <h2>Update Item</h2>
        </div>
        <div className="dialog-body">
          <div className="dialog-body-row">
            <label>Item Name</label>
            <Input
              name="name"
              value={newItem?.name || item?.name}
              onChange={handleChange}
            />
          </div>
          <div className="dialog-body-row">
            <label>Price</label>
            <Input
              name="Price"
              value={newItem?.price || item?.price}
              onChange={handleChange}
            />
          </div>
          <div className="dialog-body-row">
            <label>Quantity</label>
            <Input name="quantity" onChange={handleChange} />
          </div>
          <div className="dialog-body-row">
            <label>Description</label>
            <Input name="description" onChange={handleChange}></Input>
          </div>
        </div>
        <div className="dialog-footer">
          <button className="cancel-button" onClick={handleClose}>
            Cancel
          </button>
          <button className="add-button">Update</button>
        </div>
      </div>
    </div>
  );
};

export default memo(UpdateItemDialog);
