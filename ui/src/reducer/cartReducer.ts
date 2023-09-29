import initialState from '../store/initialState';
import { CART_ADD } from '../util/Constants';

export default function cartReducer(state = initialState?.item, action: any) {
  switch (action.type) {
    case CART_ADD:
      if (!state.cart.some((el) => el.item.id === action.data.item.id)) {
        return { ...state, cart: [...state.cart, action.data] };
      }
      return state;
    default:
      return state;
  }
}
