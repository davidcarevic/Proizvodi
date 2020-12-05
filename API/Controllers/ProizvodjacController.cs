using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodjacController : ControllerBase
    {
        private readonly ICreateProizvodjacCommand _createProizvodjac;
        private readonly IEditProizvodjacCommand _editProizvodjac;
        private readonly IDeleteProizvodjacCommand _deleteProizvodjac;
        private readonly IGetProizvodjacsCommand _getProizvodjacs;
        private readonly IGetProizvodjacCommand _getProizvodjac;

        public ProizvodjacController(ICreateProizvodjacCommand createProizvodjac, IEditProizvodjacCommand editProizvodjac, IDeleteProizvodjacCommand deleteProizvodjac, IGetProizvodjacsCommand getProizvodjacs, IGetProizvodjacCommand getProizvodjac)
        {
            this._createProizvodjac = createProizvodjac;
            this._editProizvodjac = editProizvodjac;
            this._deleteProizvodjac = deleteProizvodjac;
            this._getProizvodjacs = getProizvodjacs;
            this._getProizvodjac = getProizvodjac;
        }

        // GET: api/Proizvodjac
        [HttpGet]
        public ActionResult<IEnumerable<GetProizvodjacDTO>> Get([FromQuery]Search s)
        {
            try
            {
                // Omogucena pretraga naziva slanjem query parametra Keyword
                var kategorijas = _getProizvodjacs.Execute(s);
                return Ok(kategorijas);
            }
            catch (EntityNotFoundException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        // GET: api/Proizvodjac/5
        [HttpGet("{id}", Name = "GetPP")]
        public ActionResult<GetProizvodjacDTO> Get(int id)
        {
            try
            {
                var p = _getProizvodjac.Execute(id);
                return StatusCode(200, p);
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
        public ActionResult Put(int id, [FromBody] EditProizvodjacDTO dto)
        {
            dto.Id = id;
            try
            {
                _editProizvodjac.Execute(dto);
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
                _deleteProizvodjac.Execute(id);
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
