using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.ModelCommands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.ModelCommands
{
    public class EfGetModelCommand : BaseEfCommand, IGetModelCommand
    {
        public EfGetModelCommand(ProjectContext context) : base(context)
        {
        }

        public ModelSHow Execute(int request)
        {
            var model = Context.Models.Find(request);
            if (model == null)
                throw new EntityNotFoundException("Model");
            return new ModelSHow
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
