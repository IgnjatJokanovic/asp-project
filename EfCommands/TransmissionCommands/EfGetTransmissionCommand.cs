using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.TransmissionCommands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.TransmissionCommands
{
    public class EfGetTransmissionCommand : BaseEfCommand, IGetTransmissionCommand
    {
        public EfGetTransmissionCommand(ProjectContext context) : base(context)
        {
        }

        public FuelDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
