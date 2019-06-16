using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Searches;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfGetEnginesCommand : BaseEfCommand, IGetEnginesCommand
    {
        public EfGetEnginesCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<EngineShow> Execute(EngineSearch request)
        {
            var engines = Context.Engines.AsQueryable();
            if (request.Name != null)
                engines.Where(e => e.Name.ToLower() == request.Name.ToLower());
            if (request.CC != null)
                engines.Where(e => e.CC == request.CC);
            return engines.Select(e => new EngineShow
            {
                Id = e.Id,
                CC = e.CC,
                Name = e.Name
            });
            
        }
    }
}
