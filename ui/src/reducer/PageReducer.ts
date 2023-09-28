import initialState from '../store/initialState';
import { HIDE_NOTIFICATION, SHOW_NOTIFICATION } from '../util/Constants';

export default function pageReducer(state = initialState?.page, action: any) {
  switch (action.type) {
    case SHOW_NOTIFICATION:
      return { ...state, notification: action?.notification };
    case HIDE_NOTIFICATION:
      return { ...state, notification: action?.notification };
    default:
      return state;
  }
}
