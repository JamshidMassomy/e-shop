import { connectRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import { combineReducers } from 'redux';

// import pageReducer from './pageReducer';

export const history = createBrowserHistory();
const rootReducer = combineReducers({
  // page: pageReducer,
  router: connectRouter(history),
});

export default rootReducer;
