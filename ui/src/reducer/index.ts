import { combineReducers } from 'redux';
import pageReducer from './PageReducer';
import itemReducer from './ItemReducer';

const rootReducer = combineReducers({
  page: pageReducer,
  item: itemReducer,
});

export default rootReducer;
