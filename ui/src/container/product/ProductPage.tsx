// react
import React, { memo, useEffect, useState } from 'react';
import toast, { Toaster } from 'react-hot-toast';

// api
import { _fetch } from '../../api/api.config';

// component
import ItemTable from '../../components/item_table/ItemTable';
import AddCartDialog from '../../components/add_cart_dialog/AddCartDialog';
import DeleteItemDialog from '../../components/delete_item/DeleteItemDialog';
import CreateItemDialog from '../../components/create_item_dialog/CreateItemDialog';
import { Button } from '../../components/button';
import UpdateItem from '../../components/update_item/UpdateItem';

// styles
import './ProductPageStyles.scss';

// types
import { IItem, IResponse } from '../../types';

const ProductPage = () => {
  const [isUpdateActive, setIsUpdateActive] = useState<boolean>(false);
  const [isDeleteActive, setIsDeleteActive] = useState<boolean>(false);
  const [isAddCartOpen, setIsAddCartOpen] = useState<boolean>(false);
  const [isCreateDialogOpen, setIsCreateDialogOpen] = useState<boolean>(false);
  const [itemData, setItemData] = useState<IItem[]>([]);
  const [activeItem, setActiveItem] = useState<IItem>();

  useEffect(() => {
    fetchItems();
  }, []);

  const fetchItems = async () => {
    await _fetch('/Item')
      .then((data: IResponse | any) => {
        if (!data) {
          toast('Something went wrong unable to fetch data');
        }
        console.log('data', data);
        setItemData(data.result);
      })
      .catch(() => {
        toast('Something went wrong or back-end server is not stable');
      });
  };

  const handleCreateItem = async () => {
    setIsCreateDialogOpen(!isCreateDialogOpen);
  };

  const handleUpdateItem = async (item: IItem) => {
    setIsUpdateActive(!isUpdateActive);
    initlizeItem(item);
  };

  const handleDeleteItem = async (item: IItem) => {
    setIsDeleteActive(!isDeleteActive);
    initlizeItem(item);
  };

  const handleAddToCart = async (item: IItem) => {
    setIsAddCartOpen(!isAddCartOpen);
    initlizeItem(item);
  };

  const initlizeItem = (item: IItem) => {
    setActiveItem(item);
  };

  return (
    <>
      <Toaster position="top-right" />
      <DeleteItemDialog isOpen={isDeleteActive} />
      <AddCartDialog isOpen={isAddCartOpen} item={activeItem} />
      <CreateItemDialog isOpen={isCreateDialogOpen} />
      <UpdateItem
        isOpen={isUpdateActive}
        item={activeItem as any}
        oldItem={activeItem}
      />
      <div className="product-container">
        <div className="btn-create">
          <Button onClick={handleCreateItem} label={'create item'} />
        </div>

        <ItemTable
          dataset={itemData}
          deleteItem={handleDeleteItem}
          addToCart={handleAddToCart as any}
          update={handleUpdateItem}
        />
      </div>
    </>
  );
};

export default memo(ProductPage);
