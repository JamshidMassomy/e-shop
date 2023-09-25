import React, { memo } from 'react';
import './HomePage.scss';
import ProductPage from '../product/ProductPage';
import Header from '../../components/header/Header';

const HomePage: React.FC<any> = () => {
  return (
    <div>
      <Header></Header>
      <ProductPage></ProductPage>
      <h1>I am home page</h1>
    </div>
  );
};

export default memo(HomePage);
