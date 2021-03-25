import vehicles from "../reducers/vehicles.reducer";
import { VEHICLES_GET_REQUEST, VEHICLES_GET_RESPONSE } from "../action-types";

describe("When fetching vehicles", () => {
  test("state should be busy when fetching", () => {
    let result = vehicles({}, { type: VEHICLES_GET_REQUEST });
    expect(result.isBusy).toEqual(true);
  });
  test("state should not be busy when fetching complete", () => {
    let result = vehicles(
      {},
      { type: VEHICLES_GET_RESPONSE, payload: [{ id: 1 }] }
    );
    expect(result.isBusy).toEqual(false);
  });
  test("should fetch vehicles list", () => {
    let result = vehicles(
      {},
      { type: VEHICLES_GET_RESPONSE, payload: [{ id: 1 }] }
    );
    expect(result.items.length).toEqual(1);
  });
});
