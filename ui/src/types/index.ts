export interface IItem {
  id?: number;
  name?: string;
  description?: string;
  price?: number;
  quantity?: number;
  onEdit?: (item: IItem) => void;
  onDelete?: (id: number) => void;
  onView?: (item: IItem) => void;
  onAddCart?: (item: IItem) => void;
}

export interface IToken {
  token: string;
  expDate: Date;
}
