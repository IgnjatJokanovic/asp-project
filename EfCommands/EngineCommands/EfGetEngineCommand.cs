using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;

namespace EfCommands.EngineCommands
{
    public class EfGetEngineCommand : BaseEfCommand, IGetEngineCommand
    {
        public EfGetEngineCommand(ProjectContext context) : base(context)
        {
        }

        public EngineShow Execute(int request)
        {
            var engine = Context.Engines.Find(request);
            if (engine == null)
                throw new EntityNotFoundException("Engine");

            return new EngineShow
            {
                Id = engine.Id,
                Name = engine.Name,
                CC = engine.CC
            };
        }
    }
}
