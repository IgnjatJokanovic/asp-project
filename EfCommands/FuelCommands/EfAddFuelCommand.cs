using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Commands.FuelCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EfDataAccess;

namespace EfCommands.FuelCommands
{
    public class EfAddFuelCommand : BaseEfCommand, IAddFuelCommand
    {
        public EfAddFuelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(FuelDto request)
        {
            var fuel = new Fuel();
            if (Context.Fuels.Any(f => f.Type.ToLower() == request.Type.ToLower()))
                throw new EntityAlreadyExistsException("Fuel");
            fuel.Type = request.Type;
            Context.Fuels.Add(fuel);
            Context.SaveChanges();

        }
    }
}
