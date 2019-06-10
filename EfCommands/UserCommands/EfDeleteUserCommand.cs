using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EfDeleteUserCommand : BaseEfCommand, IDeleteUserCommand
    {
        public EfDeleteUserCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
