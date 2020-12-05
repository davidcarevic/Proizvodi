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
    public class ProizvodjacController : ControllerBase
    {
        private readonly ICreateProizvodjacCommand _createProizvodjac;

        public ProizvodjacController(ICreateProizvodjacCommand createProizvodjac)
        {
            this._createProizvodjac = createProizvodjac;
        }

        // GET: api/Proizvodjac
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Proizvodjac/5
        [HttpGet("{id}", Name = "GetPP")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Proizvodjac
        [HttpPost]
        public ActionResult Post([FromBody] CreateProizvodjacDTO dto)
        {
            try
            {
                _createProizvodjac.Execute(dto);
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

        // PUT: api/Proizvodjac/5
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
