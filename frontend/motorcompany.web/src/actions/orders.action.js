import * as api from "../mocks/api/orders.api";
import {
  ORDER_BUILD_VEHICLE_GET,
  ORDER_BUILD_REQUEST,
  ORDER_BUILD_RESPONSE,
  ORDER_BUILD_SUBMITTED,
  ORDERS_GET_REQUEST,
  ORDERS_GET_RESPONSE,
  ORDERS_ERRORS,
  ORDERS_CLEAR_ERRORS,
  ORDER_PUT_REQUEST,
  ORDER_PUT_RESPONSE,
  ORDER_STATES
} from "../action-types";
import orderState from './order-state';

import { toOrders } from "./mappers";

export function onBuild(payload) {
  return { type: ORDER_BUILD_VEHICLE_GET, payload };
}

export function onOrderSubmitted() {
  return { type: ORDER_BUILD_SUBMITTED };
}

export const onClearErrors = () => dispatch => {
  dispatch({ type: ORDERS_CLEAR_ERRORS });
};

const getOrders = (fetch, dispatch) => {
  dispatch({ type: ORDERS_GET_REQUEST });
  fetch()
    .then(dto => {
      dispatch({
        type: ORDERS_GET_RESPONSE,
        payload: toOrders(dto)
      })
    })
    .catch(errorsDto => {
      dispatch({ type: ORDERS_ERRORS, payload: errorsDto });
    });
};

export const onGetOrders = state => dispatch => {
  getOrders(() => api.getOrders(state), dispatch);
};

export const onGetGivenOrder = id => dispatch => {
  getOrders(() => api.getOrder(id), dispatch);
};

export const onGetNextOrder = () => dispatch => {
  getOrders(() => api.getOrders(orderState.started), dispatch);
};

export const onSetOrderState = (id, state) => dispatch => {
  dispatch({ type: ORDER_PUT_REQUEST });
  api
    .setOrderState(id, ORDER_STATES[state])
    .then(() => {
      dispatch({
        type: ORDER_PUT_RESPONSE,
        payload: { id, state }
      });
    })
    .catch(errorsDto => {
      dispatch({ type: ORDERS_ERRORS, payload: errorsDto });
    });
};

export function onBuildOrder(customer, vehicle) {
  return dispatch => {
    dispatch({ type: ORDER_BUILD_REQUEST });
    api
      .orderNewBuild(customer.id, vehicle.id)
      .then(dto => {
        dispatch({ type: ORDER_BUILD_RESPONSE, payload: dto });
      })
      .catch(dto => {
        dispatch({ type: ORDERS_ERRORS, payload: dto });
      });
  };
}
