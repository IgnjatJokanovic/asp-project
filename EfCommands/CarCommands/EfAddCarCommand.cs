using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;

namespace EfCommands.CarCommands
{
    public class EfAddCarCommand : BaseEfCommand, IAddCarCommand
    {
        public EfAddCarCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(CarDto request)
        {
            if (Context.Cars.Any(c => c.Name == request.Name))
                throw new EntityAlreadyExistsException("Car");

            var car = new Car();
            car.Name = request.Name;
            car.Price = request.Price;
            car.Src = request.Src;
            car.Alt = request.Name;
            car.EngineId = request.EngineId;
            car.FuelId = request.FuelId;
            car.ModelId = request.ModelId;
            car.TransmissionId = request.TransmissionId;
            car.CarEquipment = new List<CarEquipment>();
            foreach (EquipmentDto dto in request.Equipment)
            {
                var equipment = Context.Equipment.Find(dto.Id);
                var CarEquipment = new CarEquipment();
                CarEquipment.Equipment = equipment;
                car.CarEquipment.Add(CarEquipment);
            }
            
            Context.Cars.Add(car);
            Context.SaveChanges();





        }
    }
}
