import React, { memo } from 'react';
import { LABELS } from '../../util/Constants';
import './LogoutButton.scss';

const LogoutButton = ({ onClick }: any) => {
  return (
    <button className="logout-button" onClick={onClick}>
      {LABELS.LOG_OUT}
    </button>
  );
};

export default memo(LogoutButton);
