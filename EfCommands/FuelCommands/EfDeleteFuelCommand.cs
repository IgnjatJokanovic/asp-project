using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.FuelCommands;
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
            throw new NotImplementedException();
        }
    }
}
