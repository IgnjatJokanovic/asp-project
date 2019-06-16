using Application.Commands.UserCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.UserCommands
{
    public class EfLoginCommand : BaseEfCommand, ILoginCommand
    {
        public EfLoginCommand(ProjectContext context) : base(context)
        {
        }

        public LoggedUser Execute(UserLoginDto request)
        {
            var user = Context.Users
            .Include(u => u.Role)
            .Where(u => u.Username == request.Username && u.Password == u.Password)
            .FirstOrDefault();

            if (user == null)
                throw new EntityNotFoundException("User");

            return new LoggedUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.Name,
                IsLogged = true,
                Username = user.Username
            };
            


        }
    }
}
