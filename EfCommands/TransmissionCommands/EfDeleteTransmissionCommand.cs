using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.TransmissionCommands;
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
            throw new NotImplementedException();
        }
    }
}
