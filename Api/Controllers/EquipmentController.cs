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
    public class EquipmentController : ControllerBase
    {
        private readonly IAddEquipmentCommand _add;
        private readonly IEditEquipmentCommand _edit;
        private readonly IDeleteEquipmentCommand _delete;
        private readonly IGetEquipmentsCommand _getS;
        private readonly IGetEquipmentCommand _get;

        public EquipmentController(IAddEquipmentCommand add, IEditEquipmentCommand edit, IDeleteEquipmentCommand delete, IGetEquipmentsCommand getS, IGetEquipmentCommand get)
        {
            _add = add;
            _edit = edit;
            _delete = delete;
            _getS = getS;
            _get = get;
        }



        // GET: api/Equipment
        [HttpGet]
        public ActionResult<IEnumerable<EquipmentShow>> Get([FromQuery]EquipmentSearch query)
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

        // GET: api/Equipment/5
        [HttpGet("{id}")]
        public ActionResult<EquipmentShow> Get(int id)
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

        // POST: api/Equipment
        [HttpPost]
        public ActionResult Post([FromBody] EquipmentDto dto)
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

        // PUT: api/Equipment/5
        [HttpPut]
        public ActionResult Put([FromBody] EquipmentDto dto)
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
