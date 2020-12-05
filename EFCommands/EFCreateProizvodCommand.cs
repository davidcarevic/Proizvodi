using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands
{
    public class EFCreateProizvodCommand:BaseEFCommand, ICreateProizvodCommand
    {
        public EFCreateProizvodCommand(ProizvodiContext context) : base(context) { }

        public void Execute(CreateProizvodDTO request) {

            // predpostavljacu da i proizvodi moraju imati unikatno ime iako nije realno
            if (_context.Proizvods.Any(k => k.Naziv.ToLower().Contains(request.Naziv.ToLower())))
            {
                throw new EntityAlreadyExistsException("This article ");
            }

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

            _context.Proizvods.Add(new Proizvod
            {
                Naziv = request.Naziv,
                Opis = request.Opis,
                Cena = request.Cena,
                KatId = request.KatId,
                DobId = request.DobId,
                ProId = request.ProId,
                ModifiedOn = null
            });

            _context.SaveChanges();

        }
    }
}
