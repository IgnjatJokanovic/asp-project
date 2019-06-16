using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfEditEngineCommand : BaseEfCommand, IEditEngineCommand
    {
        public EfEditEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(EngineDto request)
        {
            var engine = Context.Engines.Find(request.Id);
            if (Context.Engines.Any(e => e.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Engine");
            engine.Name = request.Name;
            engine.CC = request.CC;
            Context.SaveChanges();
        }
    }
}
