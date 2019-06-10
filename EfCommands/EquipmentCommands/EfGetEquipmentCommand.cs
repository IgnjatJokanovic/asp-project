using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfGetEquipmentCommand : BaseEfCommand, IGetEquipmentCommand
    {
        public EfGetEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public EquipmentDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
