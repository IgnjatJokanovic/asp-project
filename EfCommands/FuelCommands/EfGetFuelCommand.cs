using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.FuelCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.FuelCommands
{
    public class EfGetFuelCommand : BaseEfCommand, IGetFuelCommand
    {
        public EfGetFuelCommand(ProjectContext context) : base(context)
        {
        }

        public FuelDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
