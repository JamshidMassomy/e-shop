// react
import React, { memo, useEffect, useState } from 'react';
import toast, { Toaster } from 'react-hot-toast';

// api
import { _fetch } from '../../api/api.config';

// component
import ItemTable from '../../components/item_table/ItemTable';
import AddCartDialog from '../../components/add_cart_dialog/AddCartDialog';
import CreateItemDialog from '../../components/create_item_dialog/CreateItemDialog';
import { Button } from '../../components/button';
import UpdateItem from '../../components/update_item/UpdateItem';

// styles
import './ProductPageStyles.scss';

// types
import { IItem, IResponse } from '../../types';
import { ERROR_LABLES } from '../../util/Constants';

const ProductPage = () => {
  const [isUpdateActive, setIsUpdateActive] = useState<boolean>(false);
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
          toast(ERROR_LABLES.SOMETHING_WENT_WRONG);
        }
        setItemData(data.result);
      })
      .catch(() => {
        toast(ERROR_LABLES.SOMETHING_WENT_WRONG);
      });
  };

  const handleCreateItem = async () => {
    if (!isCreateDialogOpen) {
      setIsCreateDialogOpen(true);
    }
  };

  const handleUpdateItem = async (item: IItem) => {
    setIsUpdateActive(!isUpdateActive);
    initlizeItem(item);
  };

  const handleDeleteItem = async (item: IItem) => {
    if (item.id) {
      await _fetch(`/Item/${item.id}`, {
        method: 'DELETE',
      })
        .then(() => {
          toast(ERROR_LABLES.SOMETHING_WENT_WRONG);
        })
        .catch(() => {
          toast(ERROR_LABLES.SOMETHING_WENT_WRONG);
        });
    }
    handleRefresh();
  };

  const handleAddToCart = async (item: IItem) => {
    setIsAddCartOpen(!isAddCartOpen);
    initlizeItem(item);
  };

  const initlizeItem = (item: IItem) => {
    setActiveItem(item);
  };

  const handleRefresh = async () => {
    setIsUpdateActive(false);
    setIsCreateDialogOpen(false);
    setIsAddCartOpen(false);
    await fetchItems();
  };

  return (
    <>
      <Toaster position="top-right" />
      <AddCartDialog
        isOpen={isAddCartOpen}
        item={activeItem}
        handleClose={() => {
          setActiveItem(undefined);
          setIsAddCartOpen(false);
        }}
      />
      <CreateItemDialog
        handleClose={() => setIsCreateDialogOpen(false)}
        isOpen={isCreateDialogOpen}
        handleRefresh={handleRefresh}
      />
      <UpdateItem
        handleClose={() => setIsUpdateActive(false)}
        handleRefresh={handleRefresh}
        isOpen={isUpdateActive}
        item={activeItem as any}
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
