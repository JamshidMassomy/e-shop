import React, { memo } from 'react';
import './DialogStyles.scss';

const Dialog: React.FC<any> = ({ handleClose, isActive, children }) => {
  return (
    <div className="modal-backdrop" onClick={() => handleClose()}>
      <div className={`item-dialog ${isActive ? 'open' : ''}`}>
        <div
          className="dialog-content"
          onClick={(e) => {
            e.stopPropagation();
          }}
        >
          {children}
        </div>
      </div>
    </div>
  );
};

export default memo(Dialog);
