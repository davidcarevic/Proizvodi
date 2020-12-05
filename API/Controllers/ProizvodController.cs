﻿using System;
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
    public class ProizvodController : ControllerBase
    {
        private readonly ICreateProizvodCommand _createProizvod;
        private readonly IEditProizvodCommand _editProizvod;

        public ProizvodController(ICreateProizvodCommand createProizvod, IEditProizvodCommand editProizvod) {
            this._createProizvod = createProizvod;
            this._editProizvod = editProizvod;
        }

        // GET: api/Proizvod
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Proizvod/5
        [HttpGet("{id}", Name = "Getp")]
        public string Get(int id)
        {
            return "value";
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
        public void Delete(int id)
        {
        }
    }
}