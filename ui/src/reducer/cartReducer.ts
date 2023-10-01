import initialState from '../store/initialState';
import { CART_ADD, CART_REMOVE } from '../util/Constants';

export default function cartReducer(state = initialState?.item, action: any) {
  switch (action.type) {
    case CART_ADD:
      console.log(action);
      if (!state?.cart.some((el) => el.id === action.payload.id)) {
        return { ...state, cart: [...state.cart, action.payload] };
      }
      return state;
    case CART_REMOVE:
      const elementIndex = state.cart.findIndex(
        (el) => el.id === action.payload.id
      );
      if (elementIndex !== -1) {
        const newCart = [
          ...state.cart.slice(0, elementIndex),
          ...state.cart.slice(elementIndex + 1),
        ];
        return { ...state, cart: newCart };
      }
      return state;
    default:
      return state;
  }
}
