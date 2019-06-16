using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EfCommands.EngineCommands
{
    public class EfAddEngineCommand : BaseEfCommand, IAddEngineCommand
    {
        public EfAddEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EngineDto request)
        {
            var engine = new Engine();
            if (Context.Engines.Any(e => e.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Engine");
            engine.Name = request.Name;
            engine.CC = request.CC;
            Context.Engines.Add(engine);
            Context.SaveChanges();

        }
    }
}
