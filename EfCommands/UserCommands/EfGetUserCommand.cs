using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EfGetUserCommand : BaseEfCommand, IGetUserCommand
    {
        public EfGetUserCommand(ProjectContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
