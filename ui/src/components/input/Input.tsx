import React from 'react';
import './InputStyles.scss';

interface IInput {
  placeholder?: string;
  value?: any;
  name?: string;
  disabled?: any;
  onChange: (event: any) => void;
}

const Input = (props: IInput) => {
  const { placeholder, value, onChange, name, disabled } = props;

  return (
    <div>
      <input
        disabled={disabled}
        name={name}
        className="custom-input"
        autoFocus
        type="text"
        placeholder={placeholder}
        value={value}
        onChange={onChange}
      />
    </div>
  );
};

export default Input;
