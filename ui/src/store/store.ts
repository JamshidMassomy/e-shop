import { configureStore } from '@reduxjs/toolkit';
import thunk from 'redux-thunk';
import rootReducer from '../reducer';

// export const history = createBrowserHistory();
const preloadedState = {};
const store = configureStore({
  //middleware: [thunk, routerMiddleware(history)],
  reducer: rootReducer,
  preloadedState,
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export default store;
