import {
  HIDE_DIALOG,
  HIDE_NOTIFICATION,
  SHOW_DIALOG,
  SHOW_NOTIFICATION,
} from '../util/Constants';

export const showNotification = (payload: any) => (dispatch: any) => {
  const notification = { message: payload, isActive: true };
  dispatch({ type: SHOW_NOTIFICATION, notification });
};

export const showDialog = () => (dispatch: any) => {
  const isDialogActive = { isDialogActive: true };
  dispatch({ type: SHOW_DIALOG, isDialogActive });
};

export const hideDialog = () => (dispatch: any) => {
  dispatch({ type: HIDE_DIALOG });
};

export const hideNotification = () => (dispatch: any) => {
  dispatch({ type: HIDE_NOTIFICATION });
};
