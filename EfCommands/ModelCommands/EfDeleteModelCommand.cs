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
    public class EfDeleteModelCommand : BaseEfCommand, IDeleteModelCommand
    {
        public EfDeleteModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var model = Context.Models.Find(request);
            if (model == null)
                throw new EntityNotFoundException("Model");
            Context.Models.Remove(model);
            Context.SaveChanges();
        }
    }
}
