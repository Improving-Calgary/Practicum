import * as crmApi from "../mocks/api/crm.api";
import * as vehiclesApi from "../mocks/api/vehicles.api";

export const mapFromDto = payload =>
  payload.data.map(item => ({
    id: item.id,
    customer: crmApi.getCustomer(item.attributes.customerId),
    vehicle: vehiclesApi.getVehicle(item.attributes.vehicleId),
    state: item.attributes.state,
    date: new Date(item.attributes.creationDate)
  }));

export const mapSingleFromDto = payload => [
  {
    id: payload.data.id,
    customer: crmApi.getCustomer(payload.data.attributes.customerId),
    vehicle: vehiclesApi.getVehicle(payload.data.attributes.vehicleId),
    state: payload.data.attributes.state,
    date: new Date(payload.data.attributes.creationDate)
  }
];
