// react
import React, { memo } from 'react';

// components
import ProductPage from '../product/ProductPage';
import Header from '../../components/header/Header';

const HomePage: React.FC<any> = () => {
  return (
    <>
      <Header />
      <ProductPage />
    </>
  );
};

export default memo(HomePage);
