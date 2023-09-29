import { CART_ADD, CART_REMOVE } from '../util/Constants';

export const addCartAction = (payload: any) => (dispatch: any) => {
  dispatch({ type: CART_ADD, payload });
};

export const removeCartAction = (payload: any) => (dispatch: any) => {
  dispatch({ type: CART_REMOVE, payload });
};
