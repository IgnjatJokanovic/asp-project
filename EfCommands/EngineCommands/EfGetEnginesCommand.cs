using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfGetEnginesCommand : BaseEfCommand, IGetEnginesCommand
    {
        public EfGetEnginesCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<EngineDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
