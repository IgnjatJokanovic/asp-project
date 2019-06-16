using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.FuelCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IAddFuelCommand _add;
        private readonly IEditFuelCommand _edit;
        private readonly IDeleteFuelCommand _delete;
        private readonly IGetFuelCommand _get;
        private readonly IGetFuelsCommand _getS;

        public FuelController(IAddFuelCommand add, IEditFuelCommand edit, IDeleteFuelCommand delete, IGetFuelCommand get, IGetFuelsCommand getS)
        {
            _add = add;
            _edit = edit;
            _delete = delete;
            _get = get;
            _getS = getS;
        }

        // GET: api/Fuel
        [HttpGet]
        public ActionResult<IEnumerable<FuelShow>> Get([FromQuery]FuelSearch query)
        {
            try
            {
                return Ok(_getS.Execute(query));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);

            }
        }

        // GET: api/Fuel/5
        [HttpGet("{id}")]
        public ActionResult<FuelShow> Get(int id)
        {
            try
            {
                return Ok(_get.Execute(id));
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

        // POST: api/Fuel
        [HttpPost]
        public ActionResult Post([FromBody]FuelDto dto)
        {
            try
            {
                _add.Execute(dto);
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

        // PUT: api/Fuel/5
        [HttpPut]
        public ActionResult Put([FromBody]FuelDto dto)
        {
            try
            {
                _edit.Execute(dto);
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
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _delete.Execute(id);
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
