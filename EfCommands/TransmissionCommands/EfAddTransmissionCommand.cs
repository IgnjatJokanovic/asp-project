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
    public class EfAddTransmissionCommand : BaseEfCommand, IAddTransmissionCommand
    {
        public EfAddTransmissionCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(TransmissionDto request)
        {
            var trans = new Transmission();
            if (Context.Transmissions.Any(t => t.Type.ToLower() == t.Type.ToLower()))
                throw new EntityAlreadyExistsException("Transmission");
            trans.Type = request.Type;
            Context.Transmissions.Add(trans);
            Context.SaveChanges();
            
        }
    }
}
