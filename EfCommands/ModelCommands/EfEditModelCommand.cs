using Application.Commands.ModelCommands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.ModelCommands
{
    public class EfEditModelCommand : BaseEfCommand, IEditModelCommand
    {
        public EfEditModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(ModelDto request)
        {
            throw new NotImplementedException();
        }
    }
}
