using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.FuelCommands;
using Application.DTO;
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
            throw new NotImplementedException();
        }
    }
}
