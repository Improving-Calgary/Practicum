import * as api from "../mocks/api/crm.api";
import { ORDER_BUILD_CUSTOMER_GET } from "../action-types";

const onGetCustomer = filter => {
  return dispatch => {
    api
      .findCustomer(filter)
      .then(dto => dispatch({ type: ORDER_BUILD_CUSTOMER_GET, payload: dto }))
      .catch(errorsDto => console.log(errorsDto));
  };
};

export default onGetCustomer;
