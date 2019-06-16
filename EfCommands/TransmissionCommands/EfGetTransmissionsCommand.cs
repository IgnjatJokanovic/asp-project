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
    public class EfGetTransmissionsCommand : BaseEfCommand, IGetTransmissionsCommand
    {
        public EfGetTransmissionsCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<TransmissionShow> Execute(TransmissionSearch request)
        {
            var trans = Context.Transmissions.AsQueryable();
            if (request.Type != null)
                trans.Where(t => t.Type.ToLower() == request.Type.ToLower());
            return trans.Select(t => new TransmissionShow
            {
                Id = t.Id,
                Type = t.Type
            });
        }
    }
}
