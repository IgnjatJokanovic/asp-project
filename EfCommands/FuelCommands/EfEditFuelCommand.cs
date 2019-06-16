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
    public class EfEditFuelCommand : BaseEfCommand, IEditFuelCommand
    {
        public EfEditFuelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(FuelDto request)
        {
            var fuel = Context.Fuels.Find(request.Id);
            if (fuel == null)
                throw new EntityNotFoundException("Fuel");
            if (Context.Fuels.Any(f => f.Type.ToLower() == request.Type.ToLower()))
                throw new EntityAlreadyExistsException("Fuel");
            fuel.Type = request.Type;
            Context.SaveChanges();
        }
    }
}
