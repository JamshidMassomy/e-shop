// react
import React, { memo } from 'react';

// styles & constants
import './ProductPageStyles.scss';
import { ITEM_COLUMNS } from '../../util/Constants';
import Icon from '../../components/icon/Icon';

const ProductPage = () => {
  const handleCreateItem = async () => {};
  const handleUpdateItem = async () => {};
  const handleDeleteItem = async () => {};
  const handleViewItem = async () => {};
  const handleQuantityChange = () => {};

  return (
    <div className="product-container">
      <div className="product-table-heading">
        <button onClick={handleCreateItem}>create item</button>
        <button>Add to cart</button>
      </div>
      <table className="shoppint-cart-table">
        <thead>
          <tr>
            {ITEM_COLUMNS.map((column, index) => {
              return <th key={index}>{column}</th>;
            })}
          </tr>
        </thead>
        <tbody>
          <tr className="cart-item">
            <td>Apple</td>
            <td>
              <input
                className="quantity-input"
                type="number"
                value={1}
                onChange={handleQuantityChange}
              />
            </td>
            <td>{3.33}</td>
            <td>
              <button
                className="update-button"
                onClick={() => handleUpdateItem}
              >
                <Icon icon="edit-icon"></Icon>
              </button>
              <button
                className="delete-button"
                onClick={() => handleDeleteItem}
              >
                <Icon icon="delete-icon"></Icon>
              </button>
              <button className="view-button" onClick={() => handleViewItem}>
                <Icon icon="view-icon"></Icon>
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
};

export default memo(ProductPage);
