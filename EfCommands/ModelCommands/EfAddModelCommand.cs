using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ModelCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.ModelCommands
{
    public class EfAddModelCommand : BaseEfCommand, IAddModelCommand
    {
        public EfAddModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(ModelDto request)
        {
            throw new NotImplementedException();
        }
    }
}
