using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<UserDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
