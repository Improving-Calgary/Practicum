using MotorCompany.Orders.Core.Utility;
using System;
using System.Collections.Generic;

namespace MotorCompany.Orders.Core
{
    public class Order
    {
        public static IResult<Order> Create(int customerId, int vehicleId)
        {
            var errors = new List<IError>();

            if (customerId <= 0)
                errors.Add(new Error("Customer id must be valid."));

            if (vehicleId <= 0)
                errors.Add(new Error("Vehicle id must be valid."));

            if (errors.Count > 0)
                return Result.Failure(errors).For<Order>(null);

            return Result.Success().For(new Order(customerId, vehicleId));
        }

        private Order(int customerId, int vehicleId)
        {
            CreationDate = DateTime.Now;
            CustomerId = customerId;
            VehicleId = vehicleId;
            State = EnumOrderStates.New;
        }

        private Order() { }

        public int Id { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime CompleteDate { get; private set; }

        public EnumOrderStates State { get; private set; }

        public int CustomerId { get; private set; }

        public int VehicleId { get; private set; }

        public IResult Start()
        {
            var errors = new List<IError>();
            if (State == EnumOrderStates.Complete)
                errors.Add(new Error("Order is already completed."));

            if (errors.Count > 0)
                return Result.Failure(errors);

            State = EnumOrderStates.Start;

            return Result.Success();
        }

        public IResult Cancel()
        {
            var errors = new List<IError>();
            if (State == EnumOrderStates.Complete)
                errors.Add(new Error("Order is already completed."));

            if (State == EnumOrderStates.Start)
                errors.Add(new Error("In progress order can not be cancelled."));

            if (errors.Count > 0)
                return Result.Failure(errors);

            State = EnumOrderStates.Cancel;

            return Result.Success();
        }

        public IResult Pause()
        {
            var errors = new List<IError>();
            if (State != EnumOrderStates.Start)
                errors.Add(new Error("Order must be started."));

            if (errors.Count > 0)
                return Result.Failure(errors);

            State = EnumOrderStates.Pause;

            return Result.Success();
        }

        public IResult Complete()
        {
            var errors = new List<IError>();
            if (State != EnumOrderStates.Start)
                errors.Add(new Error("Order must be started."));

            if (errors.Count > 0)
                return Result.Failure(errors);

            State = EnumOrderStates.Complete;
            CompleteDate = DateTime.Now;

            return Result.Success();
        }
    }
}
