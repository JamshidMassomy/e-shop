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

export type mode = 'edit' | 'delete' | 'create';
