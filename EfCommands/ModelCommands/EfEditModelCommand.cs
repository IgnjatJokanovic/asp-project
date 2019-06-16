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
    public class EfEditModelCommand : BaseEfCommand, IEditModelCommand
    {
        public EfEditModelCommand(ProjectContext context) : base(context)
        {
        }

        public void Execute(ModelDto request)
        {
            var model = Context.Models.Find(request.Id);
            if (model == null)
                throw new EntityNotFoundException("Model");
            if (Context.Models.Any(m => m.Name.ToLower() == request.Name.ToLower()))
                throw new EntityAlreadyExistsException("Model");
            model.Name = request.Name;
            Context.SaveChanges();
        }
    }
}
