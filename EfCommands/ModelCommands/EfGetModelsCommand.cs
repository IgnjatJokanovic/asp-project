using Application.Commands.ModelCommands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.ModelCommands
{
    public class EfGetModelsCommand : BaseEfCommand, IGetModelsCommand
    {
        public EfGetModelsCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<ModelSHow> Execute(ModelSearch request)
        {
            var models = Context.Models.AsQueryable();
            if (request.Name != null)
                models.Where(m => m.Name.ToLower() == request.Name.ToLower());
            return models.Select(m => new ModelSHow
            {
                Id = m.Id,
                Name = m.Name
            });

        }
    }
}
