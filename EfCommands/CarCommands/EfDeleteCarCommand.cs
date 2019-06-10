using Application.Commands;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.CarCommands
{
    public class EfDeleteCarCommand : BaseEfCommand, IDeleteCarCommand
    {
        public EfDeleteCarCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var car = Context.Cars.Find(request);
            if (car == null)
                throw new EntityNotFoundException("Car");

            Context.Cars.Remove(car);

            Context.SaveChanges();
            
        }
    }
}
