using Application.DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.TransmissionCommands
{
    public interface IEditTransmissionCommand : ICommand<TransmissionDto>
    {
    }
}
