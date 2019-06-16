using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.CarCommands
{
    public class EfGetCarCommand : BaseEfCommand, IGetCarCommand
    {
        public EfGetCarCommand(ProjectContext context) : base(context)
        {
        }

        public CarShowDto Execute(int request)
        {

            var car = Context.Cars
                        .Include(c => c.Engine)
                        .Include(c => c.Model)
                        .Include(c => c.Fuel)
                        .Include(c => c.Transmission)
                        .Include(c => c.CarEquipment)
                        .ThenInclude(cp => cp.Equipment)
                        .FirstOrDefault(c => c.Id == request);
            if (car == null)
                throw new EntityNotFoundException("Car");

            return new CarShowDto
            {
                Id = car.Id,
                Name = car.Name,
                Src = car.Src,
                Alt = car.Alt,
                Price = car.Price,
                Engine = car.Engine.Name,
                Fuel = car.Fuel.Type,
                Model = car.Model.Name,
                Transmission = car.Transmission.Type,
                EquipmentNames = car.CarEquipment.Select(ce => ce.Equipment.Name)
            };
        }
    }
}
