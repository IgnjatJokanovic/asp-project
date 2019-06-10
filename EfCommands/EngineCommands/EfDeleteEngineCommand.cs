using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfDeleteEngineCommand : BaseEfCommand, IDeleteEngineCommand
    {
        public EfDeleteEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
