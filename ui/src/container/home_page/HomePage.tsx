import React, { memo } from 'react';
import ProductPage from '../product/ProductPage';
import Header from '../../components/header/Header';

const HomePage: React.FC<any> = () => {
  return (
    <div>
      <Header />
      <ProductPage />
    </div>
  );
};

export default memo(HomePage);
