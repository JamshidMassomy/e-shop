import React, { memo } from 'react';
import './ButtonStyles.scss';

interface IButton {
  onClick?: () => any;
  label: string;
  className?: string;
  type?: any;
}

const Button = (props: IButton) => {
  const { onClick, label, type } = props;

  return (
    <button type={type} className={'custom-btn'} onClick={onClick}>
      {label}
    </button>
  );
};

export default memo(Button);
