using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Commands.FuelCommands;
using Application.Commands.ModelCommands;
using Application.Commands.TransmissionCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EfDataAccess;

namespace EfCommands.TransmissionCommands
{
    public class EfDeleteTransmissionCommand : BaseEfCommand, IDeleteTransmissionCommand
    {
        public EfDeleteTransmissionCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var trans = Context.Transmissions.Find(request);
            if (trans == null)
                throw new EntityNotFoundException("Transmission");
            Context.Transmissions.Remove(trans);
            Context.SaveChanges();
        }
    }
}
