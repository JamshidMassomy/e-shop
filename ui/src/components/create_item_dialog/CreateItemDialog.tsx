// react
import React, { useEffect, useState } from 'react';

// component
import Input from '../input/Input';
import { Button } from '../button';
import { IItem } from '../../types';

// api
import { _fetch } from '../../api/api.config';

const CreateItemDialog = ({ isOpen }: any) => {
  const [isActive, setIsActive] = useState<boolean>(isOpen);
  const [item, setItem] = useState<IItem>();

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  const handleClose = () => {
    setIsActive(false);
  };

  const createItem = async () => {
    await _fetch('/Item', {
      method: 'POST',
      body: item,
    })
      .then((data: any) => {
        // setItems(data.result);
      })
      .catch((error) => {});
  };

  const handleChange = (event: any) => {
    // const { name, value } = event.target;
    // setNewItem((prevData) => ({
    //   ...prevData,
    //   [name]: value,
    // }));
    // console.log('change', { newItem, item });
  };

  return (
    <div className={`item-dialog ${isActive ? 'open' : ''}`}>
      <div className="dialog-content">
        <div className="dialog-header">
          <h2>Add Item</h2>
        </div>
        <div className="dialog-body">
          <div className="dialog-body-row">
            <label>Item Name</label>
            <Input name="name" onChange={handleChange} />
          </div>
          <div className="dialog-body-row">
            <label>Price</label>
            <Input name="Price" onChange={handleChange} />
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
          {/* <button onClick={handleClose}>
            Cancel
          </button> */}

          <Button
            onClick={handleClose}
            label="Cancel"
            className="cancel-button"
          />
          <Button onClick={createItem} label="Save"></Button>
        </div>
      </div>
    </div>
  );
};

export default CreateItemDialog;
