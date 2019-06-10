using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.FuelCommands;
using Application.DTO;
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
            throw new NotImplementedException();
        }
    }
}
