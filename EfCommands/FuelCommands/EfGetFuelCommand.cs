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
    public class EfGetFuelCommand : BaseEfCommand, IGetFuelCommand
    {
        public EfGetFuelCommand(ProjectContext context) : base(context)
        {
        }

        public FuelShow Execute(int request)
        {
            var fuel = Context.Fuels.Find(request);
            if (fuel == null)
                throw new EntityNotFoundException("Fuel");
            return new FuelShow
            {
                Id = fuel.Id,
                Type = fuel.Type
            };
        }
    }
}
