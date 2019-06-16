using Application.Commands;
using Application.DTO;
using Application.Interfaces;
using Application.Responses;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EfCommands.CarCommands
{
    public class EfGetCarsCommand : BaseEfCommand, IGetCarsCommand
    {
        public EfGetCarsCommand(ProjectContext context) : base(context)
        {
        }

        public PagedResponse<CarShowDto> Execute(CarSearch request)
        {
            var query = Context.Cars.AsQueryable();
            if (request.Name != null)
                query.Where(c => c.Name.Contains(request.Name));
            if (request.MinPrice != null && request.MaxPrice != null)
                query.Where(c => c.Price >= request.MinPrice && c.Price <= request.MaxPrice);
            if (request.ModelId != null)
                query.Where(c => c.ModelId == request.ModelId);
            if (request.TransmissionId != null)
                query.Where(c => c.TransmissionId == request.TransmissionId);
            if (request.FuelId != null)
                query.Where(c => c.FuelId == request.FuelId);
            if (request.EngineId != null)
                query.Where(c => c.EngineId == request.EngineId);

            query.Include(c => c.Engine)
                .Include(c => c.Model)
                .Include(c => c.Fuel)
                .Include(c => c.Transmission)
                .Include(c => c.CarEquipment)
                .ThenInclude(ce => ce.Equipment);

            query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var totalCount = query.Count();

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);


            return new PagedResponse<CarShowDto>
            {
                CurrentPage = request.PageNumber,
                PagesCount = pagesCount,
                TotalCount = totalCount,
                Data = query.Select(c => new CarShowDto {
                    Id = c.Id,
                    Name = c.Name,
                    Price = c.Price,
                    Model = c.Model.Name,
                    Engine = c.Engine.Name,
                    Fuel = c.Fuel.Type,
                    Src = c.Src,
                    Alt = c.Alt,
                    Transmission = c.Transmission.Type,
                    EquipmentNames = c.CarEquipment.Select(ce => ce.Equipment.Name)
                })

            };







        }
    }
}
