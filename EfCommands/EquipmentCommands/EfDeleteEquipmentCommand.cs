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
    public class EfDeleteEquipmentCommand : BaseEfCommand, IDeleteEquipmentCommand
    {
        public EfDeleteEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var equipment = Context.Equipment.Find(request);
            if (equipment == null)
                throw new EntityNotFoundException("Equipment");
            Context.Equipment.Remove(equipment);
            Context.SaveChanges();

        }
    }
}
