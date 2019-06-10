using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfDeleteEquipmentCommand : BaseEfCommand, IDeleteEquipmentCommand
    {
        public EfDeleteEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
