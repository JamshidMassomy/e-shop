import { HIDE_NOTIFICATION, SHOW_NOTIFICATION } from '../util/Constants';

export const showNotification = (payload: any) => (dispatch: any) => {
  const notification = { message: payload, isActive: true };
  dispatch({ type: SHOW_NOTIFICATION, notification });
};

export const hideNotification = () => (dispatch: any) => {
  dispatch({ type: HIDE_NOTIFICATION });
};
