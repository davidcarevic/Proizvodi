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

        public DobavljacController(ICreateDobavljacCommand createDobavljac) {
            this._createDobavljac = createDobavljac;
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
