using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IAddEngineCommand _add;
        private readonly IEditEngineCommand _edit;
        private readonly IDeleteEngineCommand _delete;
        private readonly IGetEngineCommand _getEngine;
        private readonly IGetEnginesCommand _getEngines;

        public EngineController(IAddEngineCommand add, IEditEngineCommand edit, IDeleteEngineCommand delete, IGetEngineCommand getEngine, IGetEnginesCommand getEngines)
        {
            _add = add;
            _edit = edit;
            _delete = delete;
            _getEngine = getEngine;
            _getEngines = getEngines;
        }

        // GET: api/Engine
        [HttpGet]
        public ActionResult<IEnumerable<EngineShow>> Get([FromQuery]EngineSearch query)
        {
            try
            {
                return Ok(_getEngines.Execute(query));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);

            }
        }

        // GET: api/Engine/5
        [HttpGet("{id}")]
        public ActionResult<EngineShow> Get(int id)
        {
            try
            {
                return Ok(_getEngine.Execute(id));
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

        // POST: api/Engine
        [HttpPost]
        public ActionResult Post([FromBody] EngineDto dto)
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

        // PUT: api/Engine/5
        [HttpPut]
        public ActionResult Put([FromBody] EngineDto dto)
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
