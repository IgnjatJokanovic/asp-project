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
    public class EfGetFuelsCommand : BaseEfCommand, IGetFuelsCommand
    {
        public EfGetFuelsCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<FuelShow> Execute(FuelSearch request)
        {
            var fuels = Context.Fuels.AsQueryable();
            if (request.Type != null)
                fuels.Where(f => f.Type.ToLower() == request.Type.ToLower());

            return fuels.Select(f => new FuelShow
            {
               Id = f.Id,
               Type = f.Type

            });
        }
    }
}
