import { configureStore } from '@reduxjs/toolkit';
import rootReducer from '../reducer';

const preloadedState = {};
const store = configureStore({
  reducer: rootReducer,
  preloadedState,
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export default store;
