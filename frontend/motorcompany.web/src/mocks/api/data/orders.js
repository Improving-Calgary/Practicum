import faker from 'faker';

export const orders = [
  {
    id: faker.random.number(),
    creationDate: faker.date.past(),
    startDate: faker.date.past(),
    completedDate: null,
    state: 1,
    customerId: 1,
    vehicleId: 3,
  },
  {
    id: faker.random.number(),
    creationDate: faker.date.past(),
    startDate: faker.date.past(),
    completedDate: null,
    state: 1,
    customerId: 2,
    vehicleId: 5,
  }
]


