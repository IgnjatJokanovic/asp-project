using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EfAddUserCommand : BaseEfCommand, IAddUserCommand
    {
        public EfAddUserCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}
