import * as crmApi from "../mocks/api/crm.api";
import * as vehiclesApi from "../mocks/api/vehicles.api";

export const toOrder = dto => {
  return   {
    id: dto.id,
    customer: crmApi.getCustomer(dto.customerId),
    vehicle: vehiclesApi.getVehicle(dto.vehicleId),
    state: dto.state,
    date: new Date(dto.creationDate)
  };
}

export const toOrders = dtos => dtos.map(toOrder);
