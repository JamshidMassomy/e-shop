// react
import React, { useEffect, useState } from 'react';

// component
import Input from '../input/Input';
import { Button } from '../button';
import { IItem } from '../../types';

// api
import { _fetch } from '../../api/api.config';
import toast from 'react-hot-toast';
import Dialog from '../dialog/Dialog';
import { ERROR_LABLES, SUCCESS_LABELS } from '../../util/Constants';

const CreateItemDialog = ({ isOpen, handleRefresh, handleClose }: any) => {
  const [isActive, setIsActive] = useState<boolean>();
  const [errors, setErrors] = useState<any>({});
  const [item, setItem] = useState<IItem>({
    name: '',
    description: '',
    price: undefined,
  });

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  const validateForm = () => {
    const newErrors: any = {};

    if (!item.name || item.name.length == 0) {
      newErrors.name = 'Name is required';
    }
    if (!item.price || isNaN(item.price) || item.price < 0) {
      newErrors.price = 'Price must be a valid number';
    }

    if (!item.description || item.description.length === 0) {
      newErrors.description = 'Description is required';
    }
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async () => {
    if (validateForm()) {
      await _fetch('/Item', {
        method: 'POST',
        body: item,
      })
        .then(() => {
          toast(SUCCESS_LABELS.SAVED_SUCCESS);
          refresh();
          reset();
        })
        .catch(() => {
          toast(ERROR_LABLES.SOMETHING_WENT_WRONG);
        });
    } else {
      toast(ERROR_LABLES.VALIDATION_ERROR);
    }
  };

  const handleChange = (event: any) => {
    const { name, value } = event.target;
    setItem((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const refresh = () => {
    handleRefresh();
    setIsActive(false);
    reset();
  };

  const reset = () => {
    setItem({ name: '', price: null, description: '' });
  };

  return (
    <>
      <Dialog isActive={isActive} handleClose={handleClose}>
        <div className="dialog-header">
          <h2>Add Item</h2>
        </div>
        <div className="dialog-body">
          <div className="dialog-body-row">
            <label>Item Name</label>
            <Input name="name" value={item?.name} onChange={handleChange} />
            {errors.name && <div className="error-message">{errors?.name}</div>}
          </div>
          <div className="dialog-body-row">
            <label>Price</label>
            <Input name="price" value={item.price} onChange={handleChange} />
            {errors.price && (
              <div className="error-message">{errors.price}</div>
            )}
          </div>
          <div className="dialog-body-row">
            <label>Description</label>
            <Input
              name="description"
              value={item.description}
              onChange={handleChange}
            />
            {errors.description && (
              <div className="error-message">{errors.description}</div>
            )}
          </div>
          <div className="dialog-footer">
            <Button
              onClick={() => {
                handleClose();
                reset();
              }}
              label="Cancel"
              className="cancel-button"
            />
            <Button onClick={handleSubmit} label="Save" />
          </div>
        </div>
      </Dialog>
    </>
  );
};

export default CreateItemDialog;
