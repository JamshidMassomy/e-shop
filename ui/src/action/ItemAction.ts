import { CART_ACTION } from '../util/Constants';

export const addCartAction = (payload: any) => (dispatch: any) => {
  const data = { item: payload };
  dispatch({ type: CART_ACTION, data });
};
