import axios from "axios";
import { BaseUrl } from "../settings";

export const getOrders = filter =>
  new Promise((resolve, reject) => {
    axios
      .get(`${BaseUrl}/orders${filter}`)
      .then(response => resolve(response.data))
      .catch(error => reject(error.response.data.errors));
  });

export const setOrderState = (id, state) =>
  new Promise((resolve, reject) => {
    axios
      .put(`${BaseUrl}/orders/${id}/${state}`)
      .then(response => resolve(response.data))
      .catch(error => reject(error.response.data.errors));
  });

export const orderNewBuild = (customerId, vehicleId) =>
  new Promise((resolve, reject) => {
    const axiosConfig = { headers: { "Content-Type": "application/json" } }; //  to authenticate this we would add a Bearer Token in header (out of scope for now)
    axios
      .post(`${BaseUrl}/orders`, { customerId, vehicleId }, axiosConfig)
      .then(response => resolve(response.data))
      .catch(error => reject(error.response.data.errors));
  });
