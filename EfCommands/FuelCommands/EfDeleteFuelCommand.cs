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
    public class EfDeleteFuelCommand : BaseEfCommand, IDeleteFuelCommand
    {
        public EfDeleteFuelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var fuel = Context.Fuels.Find(request);
            if (fuel == null)
                throw new EntityNotFoundException("Fuel");
            Context.Fuels.Remove(fuel);
            Context.SaveChanges();
        }
    }
}
