// react
import React from 'react';

// components
import IconButton from '../icon_button/IconButton';
import { ItemTableProps } from '../../types';

// styles
import './ItemTableStyles.scss';
import { ITEM_COLUMNS } from '../../util/Constants';

const ItemTable = (props: ItemTableProps) => {
  const { update, dataset, deleteItem, addToCart } = props;

  return (
    <div>
      <table className="shoppint-cart-table">
        <thead>
          <tr>
            {ITEM_COLUMNS.map((column, index) => {
              return <th key={index}>{column}</th>;
            })}
          </tr>
        </thead>
        <tbody>
          {dataset?.length == 0 ? (
            <span>No data avaliable</span>
          ) : (
            dataset?.map((item, index) => {
              return (
                <tr className="cart-item">
                  <td>{item.name}</td>
                  <td>{item.description}</td>
                  <td> ${item.price} </td>
                  <td>
                    <IconButton
                      onClick={() => update?.(item) as any}
                      icon="edit-icon"
                    />
                    <IconButton
                      onClick={() => deleteItem?.(item) as any}
                      icon="delete-icon"
                    />
                    <IconButton
                      onClick={() => addToCart?.(item) as any}
                      icon="shopping-cart"
                    />
                  </td>
                </tr>
              );
            })
          )}
        </tbody>
      </table>
    </div>
  );
};
export default ItemTable;
