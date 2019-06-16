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
    public class EfEditEquipmentCommand : BaseEfCommand, IEditEquipmentCommand
    {
        public EfEditEquipmentCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EquipmentDto request)
        {
            var equipmnet = Context.Equipment.Find(request.Id);
            if (equipmnet == null)
                throw new EntityNotFoundException("Equipmnet");
            if (Context.Equipment.Any(e => e.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Equipment");
            equipmnet.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
