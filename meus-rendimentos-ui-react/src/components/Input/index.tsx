import React, { InputHTMLAttributes, useEffect, useRef, useState,
useCallback } from "react";
import { IconBaseProps } from 'react-icons';
import { FiAlertCircle } from 'react-icons/fi';
import { useField } from '@unform/core';

import Tooltip from "../Tooltip";

import { Container, ContainerError } from './styles';

interface InputProps extends InputHTMLAttributes<HTMLInputElement> {
  name: string,
  icon?: React.ComponentType<IconBaseProps>;
}

const Input: React.FC<InputProps> = ({name, icon: Icon, ...rest}) => {
  const inputRef = useRef<HTMLInputElement>(null);
  const [isFocused, setIsFocused] = useState(false);
  const [isField, setIsField] = useState(false);
  const { fieldName, defaultValue, error, registerField } = useField(name);

  const handleInputFocus = useCallback(() => {
      setIsFocused(true);
  }, []);

  const hadleInputBlur = useCallback(() => {
    setIsFocused(false);

    setIsField(!!inputRef.current?.value);
  }, [])

  useEffect(() => {
    registerField({
      name: fieldName,
      ref: inputRef.current,
      path: 'value'
    });
  }, [fieldName, registerField]);

  return (
    <Container isErrored={!!error} isField={isField} isFocused={isFocused}>
      { Icon && <Icon size={20} /> }
      <input
        onFocus={handleInputFocus}
        onBlur={hadleInputBlur}
        defaultValue={defaultValue}
        ref={inputRef}
        {...rest}
      />
      
      {error && (
        <ContainerError title={error}>
          <FiAlertCircle color="#c53030" size={20} />
        </ContainerError>
      )}
    </Container>
  )
};

export default Input;