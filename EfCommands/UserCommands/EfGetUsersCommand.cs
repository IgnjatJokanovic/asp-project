using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;

namespace EfCommands.UserCommands
{
    public class EfGetUsersCommand : BaseEfCommand, IGetUsersCommand
    {
        public EfGetUsersCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<UserShow> Execute(UserSearch request)
        {
            throw new NotImplementedException();
        }
    }
}
