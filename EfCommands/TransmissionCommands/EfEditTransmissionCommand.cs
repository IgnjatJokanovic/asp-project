using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.TransmissionCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.TransmissionCommands
{
    public class EfEditTransmissionCommand : BaseEfCommand, IEditTransmissionCommand
    {
        public EfEditTransmissionCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(TransmissionDto request)
        {
            throw new NotImplementedException();
        }
    }
}
