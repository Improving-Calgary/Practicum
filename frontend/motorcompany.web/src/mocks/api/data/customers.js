import faker from "faker";

export const customers = [
  {
    id: 1,
    firstName: "Jeff",
    lastName: "Erst",
    address: faker.helpers.createCard().address.streetA,
    phone: faker.helpers.createCard().phone
  },
  {
    id: 2,
    firstName: "David",
    lastName: "Scott",
    address: faker.helpers.createCard().address.streetA,
    phone: faker.helpers.createCard().phone
  }
];
