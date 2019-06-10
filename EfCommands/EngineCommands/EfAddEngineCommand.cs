using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;


namespace EfCommands.EngineCommands
{
    public class EfAddEngineCommand : BaseEfCommand, IAddEngineCommand
    {
        public EfAddEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EngineDto request)
        {
            throw new NotImplementedException();
        }
    }
}
