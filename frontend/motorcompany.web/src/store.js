import { combineReducers, createStore, applyMiddleware, compose } from "redux";
import thunk from "redux-thunk";
import vehicles from "./reducers/vehicles.reducer";
import orders from "./reducers/orders.reducer";

export const reducers = combineReducers({
  vehicles,
  orders
});

const middleware = [thunk];
const enhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
export const store = createStore(
  reducers,
  enhancers(applyMiddleware(...middleware))
);
