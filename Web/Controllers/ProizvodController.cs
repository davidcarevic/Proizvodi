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
using Web.DTO;

namespace Web.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly ICreateProizvodCommand _createProizvod;
        private readonly IEditProizvodCommand _editProizvod;
        private readonly IDeleteProizvodCommand _deleteProizvod;
        private readonly IGetProizvodsCommand _getProizvods;
        private readonly IGetProizvodCommand _getProizvod;

        public ProizvodController(ICreateProizvodCommand createProizvod, IEditProizvodCommand editProizvod, IDeleteProizvodCommand deleteProizvodCommand, IGetProizvodsCommand getProizvods, IGetProizvodCommand getProizvod)
        {
            this._createProizvod = createProizvod;
            this._editProizvod = editProizvod;
            this._deleteProizvod = deleteProizvodCommand;
            this._getProizvods = getProizvods;
            this._getProizvod = getProizvod;
        }

        // GET: Proizvod
        public ActionResult Index([FromQuery]Search s)
        {
            try
            {
                
                var proizvods = _getProizvods.Execute(s);
               // ProizvodDTOs dto = proizvods;
                return View(proizvods);
            }
            catch (EntityNotFoundException e) { TempData["Error"] = e.Message; }
            catch (Exception e) { TempData["Error"] = "Server error " + e.Message; }
            return View();
        }

        // GET: Proizvod/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var p = _getProizvod.Execute(id);


                return View(p);
            }
            catch (EntityNotFoundException e) { TempData["Error"] = e.Message; }
            catch (Exception e) { TempData["Error"] = "Server error " + e.Message; }
            return View();
        }

        // GET: Proizvod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvod/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateProizvodDTO dto)
        {
            try
            {
                // TODO: Add insert logic here
                _createProizvod.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e) { TempData["Error"] = e.Message; }
            catch (Exception e) { TempData["Error"] = "Server error " + e.Message; }
            return View();
        }

        // GET: Proizvod/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proizvod/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] EditProizvodDTO dto)
        {
            dto.Id = id;
            try
            {
                // TODO: Add update logic here

                _editProizvod.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e) { TempData["Error"] = e.Message; }
            catch (Exception e) { TempData["Error"] = "Server error " + e.Message; }
            return View();
        }

        // GET: Proizvod/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proizvod/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _deleteProizvod.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e) { TempData["Error"] = e.Message; }
            catch (Exception e) { TempData["Error"] = "Server error " + e.Message; }
            return View();
        }
    }
}