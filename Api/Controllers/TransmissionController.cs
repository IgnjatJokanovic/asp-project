using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.TransmissionCommands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {

        private readonly IAddTransmissionCommand _add;
        private readonly IEditTransmissionCommand _edit;
        private readonly IDeleteTransmissionCommand _delete;
        private readonly IGetTransmissionCommand _get;
        private readonly IGetTransmissionsCommand _getS;

        public TransmissionController(IAddTransmissionCommand add, IEditTransmissionCommand edit, IDeleteTransmissionCommand delete, IGetTransmissionCommand get, IGetTransmissionsCommand getS)
        {
            _add = add;
            _edit = edit;
            _delete = delete;
            _get = get;
            _getS = getS;
        }

        // GET: api/Transmission
        [HttpGet]
        public ActionResult<IEnumerable<TransmissionShow>> Get([FromQuery] TransmissionSearch query)
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

        // GET: api/Transmission/5
        [HttpGet("{id}")]
        public ActionResult<TransmissionShow> Get(int id)
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

        // POST: api/Transmission
        [HttpPost]
        public ActionResult Post([FromBody] TransmissionDto dto)
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

        // PUT: api/Transmission/5
        [HttpPut]
        public ActionResult Put([FromBody] TransmissionDto dto)
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
