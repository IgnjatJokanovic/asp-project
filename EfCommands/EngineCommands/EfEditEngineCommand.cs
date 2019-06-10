using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfEditEngineCommand : BaseEfCommand, IEditEngineCommand
    {
        public EfEditEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EngineDto request)
        {
            throw new NotImplementedException();
        }
    }
}
