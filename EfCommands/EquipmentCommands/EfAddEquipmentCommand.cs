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
    public class EfAddEquipmentCommand : BaseEfCommand, IAddEquipmentCommand
    {
        public EfAddEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EquipmentDto request)
        {
            var equipment = new Equipment();
            if (Context.Equipment.Any(e => e.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Equipment");

            equipment.Name = request.Name;
            Context.Equipment.Add(equipment);
            Context.SaveChanges();
        }
    }
}
