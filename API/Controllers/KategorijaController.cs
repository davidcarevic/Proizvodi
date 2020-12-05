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
    public class KategorijaController : ControllerBase
    {
        private readonly ICreateKategorijaCommand _createKategorija;
        private readonly IEditKategorijaCommand _editKategorija;

        public KategorijaController(ICreateKategorijaCommand createkategorija, IEditKategorijaCommand editKategorija) {
            this._createKategorija = createkategorija;
            this._editKategorija = editKategorija;
        }

        // GET: api/Kategorija
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Kategorija/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}
