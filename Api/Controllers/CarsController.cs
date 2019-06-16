using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Responses;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IAddCarCommand _addCar;
        private readonly IEditCarCommand _editCar;
        private readonly IDeleteCarCommand _deleteCar;
        private readonly IGetCarCommand _getCar;
        private readonly IGetCarsCommand _getCars;
        private readonly LoggedUser _user;

        public CarsController(IAddCarCommand addCar, IEditCarCommand editCar, IDeleteCarCommand deleteCar, IGetCarCommand getCar, IGetCarsCommand getCars, LoggedUser user)
        {
            _addCar = addCar;
            _editCar = editCar;
            _deleteCar = deleteCar;
            _getCar = getCar;
            _getCars = getCars;
            _user = user;
        }






        // GET: api/Cars
        [HttpGet]
        public ActionResult<PagedResponse<CarShowDto>> Get([FromQuery]CarSearch query)
        {
            try
            {
                return Ok(_getCars.Execute(query));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);

            }
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public ActionResult<CarShowDto> Get(int id)
        {
            try
            {
                return Ok(_getCar.Execute(id));
            }
            catch(EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        // POST: api/Cars
        //[LoggedIn("admin")]
        [HttpPost]
        public ActionResult Post([FromBody] CarDto dto)
        {
            try
            {
                _addCar.Execute(dto);
                return StatusCode(201);

            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        // PUT: api/Cars/5
        //[LoggedIn("admin")]
        [HttpPut]
        public ActionResult Put([FromBody] CarDto car)
        {
            
            try
            {
                _editCar.Execute(car);
                return StatusCode(204);

            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (EntityAlreadyExistsException e)
            {
                return Conflict(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Conflict(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        //[LoggedIn("admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteCar.Execute(id);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}
