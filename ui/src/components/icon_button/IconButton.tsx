import Icon from '../icon/Icon';
import React from 'react';

import './IconButtonStyles.scss';

interface IconButton {
  icon: string;
  onClick: () => any;
}

const IconButton = (props: IconButton) => {
  const { icon, onClick } = props;
  return (
    <button className="btn" onClick={onClick}>
      <Icon icon={icon} />
    </button>
  );
};

export default IconButton;
