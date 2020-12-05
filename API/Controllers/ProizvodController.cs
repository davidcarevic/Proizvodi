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
    public class ProizvodController : ControllerBase
    {
        private readonly ICreateProizvodCommand _createProizvod;
        private readonly IEditProizvodCommand _editProizvod;
        private readonly IDeleteProizvodCommand _deleteProizvod;
        private readonly IGetProizvodsCommand _getProizvods;
        private readonly IGetProizvodCommand _getProizvod;

        public ProizvodController(ICreateProizvodCommand createProizvod, IEditProizvodCommand editProizvod, IDeleteProizvodCommand deleteProizvodCommand, IGetProizvodsCommand getProizvods, IGetProizvodCommand getProizvod) {
            this._createProizvod = createProizvod;
            this._editProizvod = editProizvod;
            this._deleteProizvod = deleteProizvodCommand;
            this._getProizvods = getProizvods;
            this._getProizvod = getProizvod;
        }

        // GET: api/Proizvod
        [HttpGet]
        public ActionResult<IEnumerable<GetProizvodDTO>> Get([FromQuery]Search s)
        {
            try
            {
                // Omogucena pretraga naziva slanjem query parametra Keyword
                var proizvods = _getProizvods.Execute(s);
                return Ok(proizvods);
            }
            catch (EntityNotFoundException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        // GET: api/Proizvod/5
        [HttpGet("{id}", Name = "Getp")]
        public ActionResult<GetProizvodDTO> Get(int id)
        {
            try
            {
                var p = _getProizvod.Execute(id);
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

        // POST: api/Proizvod
        [HttpPost]
        public ActionResult Post([FromBody] CreateProizvodDTO dto)
        {
            try
            {
                _createProizvod.Execute(dto);
                return StatusCode(201);
            }
            catch (EntityAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
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

        // PUT: api/Proizvod/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EditProizvodDTO dto)
        {
            dto.Id = id;
            try
            {
                _editProizvod.Execute(dto);
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
                _deleteProizvod.Execute(id);
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
