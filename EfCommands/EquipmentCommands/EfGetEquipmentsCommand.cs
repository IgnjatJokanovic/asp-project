using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfGetEquipmentsCommand : BaseEfCommand, IGetEquipmentsCommand
    {
        public EfGetEquipmentsCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(IEnumerable<EquipmentDto> request)
        {
            throw new NotImplementedException();
        }
    }
}
