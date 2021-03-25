import {
  ORDER_BUILD_VEHICLE_GET,
  ORDER_BUILD_CUSTOMER_GET,
  ORDER_BUILD_REQUEST,
  ORDER_BUILD_RESPONSE,
  ORDER_BUILD_SUBMITTED,
  ORDERS_GET_REQUEST,
  ORDERS_GET_RESPONSE,
  ORDERS_ERRORS,
  ORDERS_CLEAR_ERRORS,
  ORDER_PUT_REQUEST,
  ORDER_PUT_RESPONSE
} from "../action-types";

const initialState = {
  isBusy: false,
  items: [],
  errors: [],
  build: {}
};

const orders = (state = initialState, action) => {
  switch (action.type) {
    case ORDER_BUILD_VEHICLE_GET:
      return { ...state, build: { ...state.build, vehicle: action.payload } };
    case ORDER_BUILD_CUSTOMER_GET:
      return { ...state, build: { ...state.build, customer: action.payload } };
    case ORDER_BUILD_REQUEST:
      return state;
    case ORDER_BUILD_RESPONSE:
      return { ...state, build: { ...state.build, isOrdered: true } };
    case ORDER_BUILD_SUBMITTED:
      return { ...state, build: {} };

    case ORDERS_GET_REQUEST:
      return { ...state, isBusy: true };
    case ORDERS_GET_RESPONSE:
      return { ...state, isBusy: false, items: action.payload };

    case ORDER_PUT_REQUEST:
      return { ...state, isBusy: true };
    case ORDER_PUT_RESPONSE:
      return {
        ...state,
        isBusy: false,
        items: state.items.filter(p => p.id !== action.payload.id)
      };
    case ORDERS_ERRORS:
      return { ...state, isBusy: false, errors: action.payload };
    case ORDERS_CLEAR_ERRORS:
      return { ...state, isBusy: false, errors: [] };
    default:
      return state;
  }
};

export default orders;
