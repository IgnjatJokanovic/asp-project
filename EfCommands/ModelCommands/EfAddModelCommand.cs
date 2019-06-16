using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.Commands.FuelCommands;
using Application.Commands.ModelCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Domain;
using EfDataAccess;


namespace EfCommands.ModelCommands
{
    public class EfAddModelCommand : BaseEfCommand, IAddModelCommand
    {
        public EfAddModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(ModelDto request)
        {
            var model = new Model();
            if (Context.Models.Any(m => m.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Model");
            model.Name = request.Name;
            Context.Models.Add(model);
            Context.SaveChanges();
        }
    }
}
