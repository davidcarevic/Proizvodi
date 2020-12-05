using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DobavljacController : ControllerBase
    {
        private readonly ICreateDobavljacCommand _createDobavljac;
        private readonly IEditDobavljacCommand _editDobavljac;
        private readonly IDeleteDobavljacCommand _deleteDobavljac;

        public DobavljacController(ICreateDobavljacCommand createDobavljac, IEditDobavljacCommand editDobavljac, IDeleteDobavljacCommand deleteDobavljac) {
            this._createDobavljac = createDobavljac;
            this._editDobavljac = editDobavljac;
            this._deleteDobavljac = deleteDobavljac;
        }

        // GET: api/Dobavljac
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Dobavljac/5
        [HttpGet("{id}", Name = "GetD")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dobavljac
        [HttpPost]
        public ActionResult Post([FromBody] CreateDobavljacDTO dto)
        {
            try
            {
                _createDobavljac.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Dobavljac/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EditDobavljacDTO dto)
        {
            dto.Id = id;
            try
            {
                _editDobavljac.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e) { return NotFound(e.Message); }

            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteDobavljac.Execute(id);
                return StatusCode(200);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
