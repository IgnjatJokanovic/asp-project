using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.TransmissionCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.TransmissionCommands
{
    public class EfGetTransmissionsCommand : BaseEfCommand, IGetTransmissionsCommand
    {
        public EfGetTransmissionsCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<TransmissionDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
