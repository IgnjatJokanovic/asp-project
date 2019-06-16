using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.CarCommands
{
    public class EfEditCarCommand : BaseEfCommand, IEditCarCommand
    {
        public EfEditCarCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(CarDto request)
        {
            var car = Context.Cars
                .Include(c => c.CarEquipment)
                .ThenInclude(ce => ce.Equipment)
                .FirstOrDefault(c => c.Id == request.Id);
            if (car == null)
                throw new EntityNotFoundException("Car");
            if (Context.Cars.Any(c => c.Name == request.Name))
                throw new EntityAlreadyExistsException("Car");
            car.Name = request.Name;
            car.Price = request.Price;
            car.Src = request.Src;
            car.ModelId = request.ModelId;
            car.Alt = request.Name;
            car.EngineId = request.EngineId;
            car.FuelId = request.FuelId;
            car.TransmissionId = request.TransmissionId;
            car.CarEquipment.Clear();
            foreach (EquipmentDto dto in request.Equipment)
            {
                var equipment = Context.Equipment.Find(dto.Id);
                if (equipment == null)
                    throw new EntityNotFoundException("Equipment");
                var CarEquipment = new CarEquipment();
                CarEquipment.Equipment = equipment;
                car.CarEquipment.Add(CarEquipment);
               

            }

            Context.SaveChanges();
        }
    }
}
