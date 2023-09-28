export interface IItem {
  id?: number;
  name?: string;
  description?: string;
  price?: number;
  quantity?: number;
}

export interface IToken {
  token: string;
  expDate: Date;
}

export interface IResponse {
  currentPage: number;
  result: any;
  totalItems: number;
  totalPages: number;
}

export interface ItemTableProps {
  update?: (item: IItem) => {};
  deleteItem?: (item: IItem) => {};
  addToCart: (item: IItem) => {};
  dataset?: any[];
}

export interface IUpdateItem {
  isOpen: boolean;
  oldItem?: IItem;
  newItem?: IItem;
  item?: IItem;
}
