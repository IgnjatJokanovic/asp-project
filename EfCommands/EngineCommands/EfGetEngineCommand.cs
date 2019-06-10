using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using EfDataAccess;

namespace EfCommands.EngineCommands
{
    public class EfGetEngineCommand : BaseEfCommand, IGetEngineCommand
    {
        public EfGetEngineCommand(ProjectContext context) : base(context)
        {
        }

        public EngineDto Execute(int request)
        {
            throw new NotImplementedException();
        }
    }
}
