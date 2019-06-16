using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.Exceptions;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfDeleteEngineCommand : BaseEfCommand, IDeleteEngineCommand
    {
        public EfDeleteEngineCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var engine = Context.Engines.Find(request);
            if (engine == null)
                throw new EntityNotFoundException("Engine");
            Context.Engines.Remove(engine);
            Context.SaveChanges();
        }
    }
}
