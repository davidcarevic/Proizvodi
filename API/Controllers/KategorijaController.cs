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
    public class KategorijaController : ControllerBase
    {
        private readonly ICreateKategorijaCommand _createKategorija;
        private readonly IEditKategorijaCommand _editKategorija;
        private readonly IDeleteKategorijaCommand _deleteKategorija;
        private readonly IGetKategorijasCommand _getKategorijas;
        private readonly IGetKategorijaCommand _getKategorija;

        public KategorijaController(ICreateKategorijaCommand createkategorija, IEditKategorijaCommand editKategorija, IDeleteKategorijaCommand deleteKategorija, IGetKategorijasCommand getKategorijas, IGetKategorijaCommand getKategorija ) {
            this._createKategorija = createkategorija;
            this._editKategorija = editKategorija;
            this._deleteKategorija = deleteKategorija;
            this._getKategorijas = getKategorijas;
            this._getKategorija = getKategorija;
         
        }

        // GET: api/Kategorija
        [HttpGet]
        public ActionResult<IEnumerable<GetKategorijaDTO>> Get([FromQuery]Search s)
        {
            try
            {
                // Omogucena pretraga naziva slanjem query parametra Keyword
                var kategorijas = _getKategorijas.Execute(s);
                return Ok(kategorijas);
            }
            catch (EntityNotFoundException e) { return NotFound(e.Message); }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        // GET: api/Kategorija/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<GetKategorijaDTO> Get(int id)
        {
            try
            {
                var p = _getKategorija.Execute(id);
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

        // POST: api/Kategorija
        [HttpPost]
        public ActionResult Post([FromBody] CreateKategorijaDTO dto)
        {
            try {
                _createKategorija.Execute(dto);
                return StatusCode(201);
            }
            catch(EntityAlreadyExistsException e) {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        // PUT: api/Kategorija/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EditKategorijaDTO dto)
        {
            dto.Id = id;
            try
            {
                _editKategorija.Execute(dto);
                return StatusCode(204);
            }
            catch (EntityNotFoundException e) { return NotFound(e.Message); }

            catch (Exception e) { return StatusCode(500, e.Message); }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try {
                _deleteKategorija.Execute(id);
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
