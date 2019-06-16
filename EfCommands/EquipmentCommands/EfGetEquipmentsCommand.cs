using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EfDataAccess;

namespace EfCommands.EquipmentCommands
{
    public class EfGetEquipmentsCommand : BaseEfCommand, IGetEquipmentsCommand
    {
        public EfGetEquipmentsCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<EquipmentShow> Execute(EquipmentSearch request)
        {
            var equipmnet = Context.Equipment.AsQueryable();
            if(request.Name != null)
            equipmnet.Where(e => e.Name.ToLower() == request.Name.ToLower());

            return equipmnet.Select(e => new EquipmentShow
            {
                Name = e.Name,
                Id = e.Id
            });
        }
    }
}
