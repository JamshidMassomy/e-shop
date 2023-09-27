import React from 'react';
import { ITEM_COLUMNS } from '../../util/Constants';
import Icon from '../icon/Icon';
import { IItem } from '../../types';
import './ItemTableStyles.scss';

interface ItemTableProps {
  create?: (item: IItem) => {};
  view?: (item: IItem) => {};
  update?: (item: IItem) => {};
  deleteItem?: (item: IItem) => {};
  dataset?: any[];
}

const ItemTable = (props: ItemTableProps) => {
  const { create, view, update, dataset, deleteItem } = props;

  return (
    <div className="product-container">
      <div className="product-table-heading">
        <button onClick={() => create}>create item</button>
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
          {dataset?.map((item, index) => {
            return (
              <tr className="cart-item">
                <td>{item.name}</td>
                <td>{item.description}</td>
                <td> ${item.price} </td>
                <button
                  className="update-button"
                  onClick={() => update?.(item)}
                >
                  <Icon icon="edit-icon"></Icon>
                </button>
                <button
                  className="delete-button"
                  onClick={() => deleteItem?.(item)}
                >
                  <Icon icon="delete-icon"></Icon>
                </button>
                <button className="view-button" onClick={() => view?.(item)}>
                  <Icon icon="view-icon"></Icon>
                </button>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};
export default ItemTable;
