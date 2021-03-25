import * as api from "../mocks/api/vehicles.api";
import { VEHICLES_GET_REQUEST, VEHICLES_GET_RESPONSE } from "../action-types";

const onGetVehicles = filter => {
  return dispatch => {
    dispatch({ type: VEHICLES_GET_REQUEST });
    api
      .getVehicles(filter)
      .then(dto => dispatch({ type: VEHICLES_GET_RESPONSE, payload: dto }))
      .catch(errorsDto => console.log(errorsDto));
  };
};

export default onGetVehicles;
