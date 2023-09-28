// react
import React, { memo, useEffect, useState } from 'react';

const DeleteItemDialog = ({ isOpen }: any) => {
  const [isActive, setIsActive] = useState<boolean>(isOpen);

  useEffect(() => {
    setIsActive(isOpen);
  }, [isOpen]);

  const handleClose = () => {
    setIsActive(!isOpen);
  };

  const handleDelete = () => {
    console.log('fetch');
  };

  return (
    <div className={`item-dialog ${isActive ? 'open' : ''}`}>
      <div className="dialog-content">
        <div className="dialog-header">
          <h2>Delet Item</h2>
        </div>
        <div className="dialog-body">
          <span>Confirm Delete</span>
        </div>
        <div className="dialog-footer">
          <button className="cancel-button" onClick={handleClose}>
            Cancel
          </button>
          <button onClick={handleDelete} className="add-button">
            Delete
          </button>
        </div>
      </div>
    </div>
  );
};

export default memo(DeleteItemDialog);
