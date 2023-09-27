import initialState from '../store/initialState';
import {
  HIDE_DIALOG,
  HIDE_NOTIFICATION,
  SHOW_DIALOG,
  SHOW_NOTIFICATION,
} from '../util/Constants';

export default function pageReducer(state = initialState?.page, action: any) {
  switch (action.type) {
    case SHOW_NOTIFICATION:
      return { ...state, notification: action?.notification };
    case HIDE_NOTIFICATION:
      return { ...state, notification: action?.notification };
    case SHOW_DIALOG:
      return { ...state, isDialogActive: true };
    case HIDE_DIALOG:
      return { ...state, isDialogActive: false };
    default:
      return state;
  }
}
