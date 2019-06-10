using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ModelCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.ModelCommands
{
    public class EfGetModelCommand : BaseEfCommand, IGetModelCommand
    {
        public EfGetModelCommand(ProjectContext context) : base(context)
        {
        }

        public ModelDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
