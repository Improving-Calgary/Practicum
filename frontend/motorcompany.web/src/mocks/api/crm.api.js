import { customers } from "./data/customers";

export const findCustomer = filter =>
  new Promise(resolve => {
    resolve(
      customers.find(
        customer =>
          customer.firstName.toLowerCase().startsWith(filter.toLowerCase()) ||
          customer.lastName.toLowerCase().startsWith(filter.toLowerCase())
      )
    );
  });

export const getCustomer = id =>
  //new Promise(resolve => {
  //resolve(
  customers.find(customer => customer.id === id);
//});
