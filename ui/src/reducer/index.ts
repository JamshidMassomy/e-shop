import { combineReducers } from 'redux';
import cartReducer from './cartReducer';

const rootReducer = combineReducers({
  item: cartReducer,
});

export default rootReducer;
