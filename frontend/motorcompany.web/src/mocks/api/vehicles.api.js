import { vehicles } from "./data/vehicles";

export const getVehicles = filter =>
  new Promise(resolve => {
    if (!filter) {
      resolve(vehicles);
    } else {
      let filteredItems = vehicles.filter(function(vehicle) {
        return (
          vehicle.make.toLowerCase().includes(filter.toLowerCase()) ||
          vehicle.model.toLowerCase().includes(filter.toLowerCase())
        );
      });
      resolve(filteredItems);
    }
  });

export const getVehicle = id =>
  //new Promise(resolve => {
  //resolve(
  vehicles.find(vehicle => vehicle.id === id);
//)});
