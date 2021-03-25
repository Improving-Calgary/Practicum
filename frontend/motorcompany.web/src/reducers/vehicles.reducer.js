import { VEHICLES_GET_REQUEST, VEHICLES_GET_RESPONSE } from "../action-types";

const initialState = {
  isBusy: false,
  items: []
};

const vehicles = (state = initialState, action) => {
  switch (action.type) {
    case VEHICLES_GET_REQUEST:
      return { ...state, isBusy: true };
    case VEHICLES_GET_RESPONSE:
      return { ...state, isBusy: false, items: action.payload };
    default:
      return state;
  }
};

export default vehicles;
