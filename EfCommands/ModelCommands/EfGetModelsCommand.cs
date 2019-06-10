using Application.Commands.ModelCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ModelCommands
{
    public class EfGetModelsCommand : BaseEfCommand, IGetModelsCommand
    {
        public EfGetModelsCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<ModelDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
