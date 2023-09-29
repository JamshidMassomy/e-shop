// react
import React, { memo, useEffect, useState } from 'react';

// types
import Input from '../input/Input';
import { IItem, IUpdateItem } from '../../types';
import { _fetch } from '../../api/api.config';
import toast from 'react-hot-toast';

const UpdateItemDialog = ({ handleRefresh, handleClose, isOpen, item }) => {
  const [isActive, setIsActive] = useState<boolean>(isOpen);
  const [updatedItem, setUpdateItem] = useState<IItem>(item);

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  useEffect(() => {
    setUpdateItem(item);
  }, [item]);

  const handleChange = (event: any) => {
    const { name, value } = event.target;

    setUpdateItem((prevData) => ({
      ...prevData,
      [name]: value,
    }));
    console.log('change', { updatedItem, item });
  };

  const handleUpdate = () => {
    if (item.id) {
      _fetch(`/Item/${item.id}`, {
        method: 'PUT',
        body: updatedItem,
      })
        .then(() => {
          toast('Updated Item');
        })
        .catch(() => {
          toast('Failed to update Item');
        });
      handleRefresh();
      handleClose();
    }
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
              value={updatedItem?.name}
              onChange={handleChange}
            />
          </div>
          <div className="dialog-body-row">
            <label>Price</label>
            <Input
              name="price"
              value={updatedItem?.price}
              onChange={handleChange}
            />
          </div>
          <div className="dialog-body-row">
            <label>Description</label>
            <Input
              name="description"
              value={updatedItem?.description}
              onChange={handleChange}
            ></Input>
          </div>
        </div>
        <div className="dialog-footer">
          <button className="cancel-button" onClick={handleClose}>
            Cancel
          </button>
          <button className="add-button" onClick={handleUpdate}>
            Update
          </button>
        </div>
      </div>
    </div>
  );
};

export default memo(UpdateItemDialog);
