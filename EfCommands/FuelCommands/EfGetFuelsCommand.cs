using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.FuelCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.FuelCommands
{
    public class EfGetFuelsCommand : BaseEfCommand, IGetFuelsCommand
    {
        public EfGetFuelsCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<FuelDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
