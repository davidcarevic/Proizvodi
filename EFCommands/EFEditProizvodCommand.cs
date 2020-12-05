using Application.Commands;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Exceptions;

namespace EFCommands
{
    public class EFEditProizvodCommand:BaseEFCommand, IEditProizvodCommand
    {
        public EFEditProizvodCommand(ProizvodiContext context) : base(context) { }

        public void Execute(EditProizvodDTO request) {

            var pro = _context.Proizvods.Find(request.Id);

            if (pro == null)
                throw new EntityNotFoundException("Article");

            if (!_context.Kategorijas.Any(r => r.Id == request.KatId))
            {
                throw new EntityNotFoundException("Category ");
            }
            if (!_context.Dobavljacs.Any(r => r.Id == request.DobId))
            {
                throw new EntityNotFoundException("Supplier ");
            }
            if (!_context.Proizvodjacs.Any(r => r.Id == request.ProId))
            {
                throw new EntityNotFoundException("Maker ");
            }

            pro.Naziv = request.Naziv;
            pro.ModifiedOn = DateTime.Now;
            pro.Cena = request.Cena;
            pro.Opis = request.Opis;
            pro.KatId = request.KatId;
            pro.DobId = request.DobId;
            pro.ProId = request.ProId;


            _context.SaveChanges();
        }
    }
}
