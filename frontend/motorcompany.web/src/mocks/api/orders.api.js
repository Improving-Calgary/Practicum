import {orders} from './data/orders';

export const getOrder = id => {
  const parsed = parseInt(id);
  return Promise.resolve(orders.filter(order => order.id === parsed));
}

export const getOrders = state => Promise.resolve(orders.filter(order => order.state === state));

export const setOrderState = (id, state) => Promise.resolve(null);

export const orderNewBuild = (customerId, vehicleId) => Promise.resolve(null);
