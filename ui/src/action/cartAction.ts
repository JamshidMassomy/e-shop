import { CART_ADD, CART_REMOVE } from '../util/Constants';

export const addCartAction = (payload: any) => (dispatch: any) => {
  const data = { item: payload };
  dispatch({ type: CART_ADD, data });
};

export const removeCartAction = (payload: any) => (dispatch: any) => {
  const data = { item: payload };
  dispatch({ type: CART_REMOVE, data });
};
