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
    public class EfGetTransmissionCommand : BaseEfCommand, IGetTransmissionCommand
    {
        public EfGetTransmissionCommand(ProjectContext context) : base(context)
        {
        }

        public TransmissionShow Execute(int request)
        {
            var trans = Context.Transmissions.Find(request);
            if (trans == null)
                throw new EntityNotFoundException("Transmission");
            return new TransmissionShow
            {
                Id = trans.Id,
                Type = trans.Type
            };
        }
    }
}
