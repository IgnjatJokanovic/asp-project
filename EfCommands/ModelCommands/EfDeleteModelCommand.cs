using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ModelCommands;
using EfDataAccess;

namespace EfCommands.ModelCommands
{
    public class EfDeleteModelCommand : BaseEfCommand, IDeleteModelCommand
    {
        public EfDeleteModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
