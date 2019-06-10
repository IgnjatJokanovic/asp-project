using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;


namespace EfCommands.CarCommands
{
    public class EfGetCarsCommand : BaseEfCommand, IGetCarsCommand
    {
        public EfGetCarsCommand(ProjectContext context) : base(context)
        {
        }

        public IEnumerable<CarDto> Execute(CarSearch request)
        {
            throw new NotImplementedException();
        }
    }
}
