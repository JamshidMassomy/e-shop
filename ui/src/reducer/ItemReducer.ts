import initialState from '../store/initialState';
import { CART_ACTION } from '../util/Constants';

export default function itemReducer(state = initialState?.item, action: any) {
  switch (action.type) {
    case CART_ACTION:
      if (!state.cart.some((el) => el.item.id === action.data.item.id)) {
        return { ...state, cart: [...state.cart, action.data] };
      }
      return state;
    default:
      return state;
  }
}
