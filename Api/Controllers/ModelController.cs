using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ModelCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IAddModelCommand _add;
        private readonly IEditModelCommand _edit;
        private readonly IDeleteModelCommand _delete;
        private readonly IGetModelCommand _get;
        private readonly IGetModelsCommand _getS;

        public ModelController(IAddModelCommand add, IEditModelCommand edit, IDeleteModelCommand delete, IGetModelCommand get, IGetModelsCommand getS)
        {
            _add = add;
            _edit = edit;
            _delete = delete;
            _get = get;
            _getS = getS;
        }

        // GET: api/Model
        [HttpGet]
        public ActionResult<IEnumerable<ModelSHow>> Get([FromQuery]ModelSearch query)
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

        // GET: api/Model/5
        [HttpGet("{id}")]
        public ActionResult<ModelSHow> Get(int id)
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

        // POST: api/Model
        [HttpPost]
        public ActionResult Post([FromBody] ModelDto dto)
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

        // PUT: api/Model/5
        [HttpPut]
        public ActionResult Put([FromBody] ModelDto dto)
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
