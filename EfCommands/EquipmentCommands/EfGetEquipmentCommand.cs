using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfGetEquipmentCommand : BaseEfCommand, IGetEquipmentCommand
    {
        public EfGetEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public EquipmentShow Execute(int request)
        {
            var equipment = Context.Equipment.Find(request);
            if (equipment == null)
                throw new EntityNotFoundException("Equipment");
            return new EquipmentShow
            {
                Id = equipment.Id,
                Name = equipment.Name
            };

        }
    }
}
