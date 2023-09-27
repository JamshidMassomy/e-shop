import { SHOW_NOTIFICATION } from '../util/Constants';

export const fetchItem = (payload: any) => (dispatch: any) => {
  const notification = { itemData: payload };
  dispatch({ type: SHOW_NOTIFICATION, notification });
};
