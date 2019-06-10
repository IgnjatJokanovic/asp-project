using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfAddEquipmentCommand : BaseEfCommand, IAddEquipmentCommand
    {
        public EfAddEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EquipmentDto request)
        {
            throw new NotImplementedException();
        }
    }
}
