// react
import React, { memo, useEffect, useState } from 'react';

// styles & constants
import './ProductPageStyles.scss';
import { _fetch } from '../../api/api.config';
import { IItem, IResponse, mode } from '../../types';
import ItemDialog from '../../components/item/item_dialog/ItemDialog';
import { useDispatch, useSelector } from 'react-redux';
import { showDialog } from '../../action/pageAction';
import ItemTable from '../../components/item_table/ItemTable';

const ProductPage = () => {
  const dialogDispatcher = useDispatch();
  const isDialogActive = useSelector(
    (state: any) => state?.page.isDialogActive
  );

  const [itemData, setItemData] = useState<IItem[]>([]);
  const [activeItem, setActiveItem] = useState<IItem>();
  const [activeMode, setActiveMode] = useState<mode>();

  useEffect(() => {
    fetchItems();
  }, []);

  const fetchItems = async () => {
    await _fetch('/Item')
      .then((data: IResponse | any) => {
        setItemData(data.result);
      })
      .catch((error) => {});
  };

  const handleCreateItem = async () => {
    setActiveMode('create');
    activateDialog();
    //initlizeItem
    console.log('adding item');
  };

  const handleUpdateItem = async (item: IItem) => {
    setActiveMode('edit');
    activateDialog();
    initlizeItem(item);
    console.log('updating itme', item);
  };

  const handleDeleteItem = async (item: IItem) => {
    setActiveMode('delete');
    activateDialog();
    initlizeItem(item);
  };

  const handleViewItem = async (item: IItem) => {
    activateDialog();
    initlizeItem(item);
  };

  const initlizeItem = (item: IItem) => {
    setActiveItem(item);
  };

  const activateDialog = () => {
    dialogDispatcher(showDialog());
    console.log(isDialogActive);
  };

  return (
    <>
      <ItemDialog
        isOpen={isDialogActive}
        onAdd={() => handleCreateItem()}
        item={activeItem as any}
        onDelete={() => handleDeleteItem}
        onUpdate={() => handleUpdateItem}
        mode={activeMode}
      />
      <ItemTable
        dataset={itemData}
        deleteItem={handleDeleteItem}
        view={handleViewItem}
        update={handleUpdateItem}
      />
    </>
  );
};

export default memo(ProductPage);
