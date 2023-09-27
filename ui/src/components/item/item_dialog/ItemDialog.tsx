import React, { memo, useEffect, useState } from 'react';

import './ItemDialogStyles.scss';
import Input from '../../input/Input';
import { IItem, mode } from '../../../types';
import { _fetch } from '../../../api/api.config';
import { useDispatch, useSelector } from 'react-redux';
import { hideDialog } from '../../../action/pageAction';

export interface ItemDialog {
  isOpen: boolean;
  item: IItem;
  onClose: () => void;
  onAdd: () => void;
  onDelete: () => void;
  onUpdate: () => void;
  mode: mode;
}

const ItemDialog = (props: ItemDialog) => {
  const { isOpen, onAdd, onClose, item, mode } = props;
  const dialogDispatcher: any = useDispatch();
  const isDialogActive = useSelector(
    (state: any) => state?.page.isDialogActive
  );

  // isactive via store, fetch via store,
  const [isActive, setIsActive] = useState<boolean>(isOpen);
  const [newItem, setNewItem] = useState<IItem>(item);

  useEffect(() => {
    setNewItem(item);
  }, []);

  const handleDelete = () => {
    console.log('delete item', item);
  };

  const handleChange = (event: any) => {
    const { name, value } = event.target;
    setNewItem((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const createItem = async () => {
    await _fetch('/Item', {
      method: 'POST',
      body: newItem,
    })
      .then((data: any) => {
        // setItems(data.result);
      })
      .catch((error) => {});
  };

  const handleClose = () => {
    console.log('closing');
    dialogDispatcher(hideDialog());
  };

  return (
    <div className={`add-item-dialog ${isDialogActive ? 'open' : ''}`}>
      <div className="dialog-content">
        <div className="dialog-header">
          <h2>Add Item</h2>
          <button className="close-button" onClick={onClose}></button>
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
          <button className="cancel-button" onClick={handleClose}>
            Cancel
          </button>

          {mode === 'delete' ? (
            <button onClick={handleDelete} className="add-button">
              Delete
            </button>
          ) : null}

          {mode === 'create' ? (
            <button className="add-button" onClick={createItem}>
              Add
            </button>
          ) : null}

          {mode === 'edit' ? (
            <button className="add-button">Update</button>
          ) : null}
        </div>
      </div>
    </div>
  );
};

export default memo(ItemDialog);
