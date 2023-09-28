import React, { memo } from 'react';
import './ButtonStyles.scss';

interface IButton {
  onClick: () => any;
  label: string;
  className?: string;
}

const Button = (props: IButton) => {
  const { onClick, label, className } = props;

  return (
    <button className={'custom-btn'} onClick={onClick}>
      {label}
    </button>
  );
};

export default memo(Button);
