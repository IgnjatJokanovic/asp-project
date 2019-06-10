using Application.Commands;
using Application.DTO;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CarCommands
{
    public class EfEditCarCommand : BaseEfCommand, IEditCarCommand
    {
        public EfEditCarCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(CarDto request)
        {
            throw new NotImplementedException();
        }
    }
}
