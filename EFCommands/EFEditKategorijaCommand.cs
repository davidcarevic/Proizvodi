using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFEditKategorijaCommand:BaseEFCommand, IEditKategorijaCommand
    {
        public EFEditKategorijaCommand(ProizvodiContext context) : base(context) { }

        public void Execute(EditKategorijaDTO request) {
            var kategorija = _context.Kategorijas.Find(request.Id);

            if (kategorija == null)
                throw new EntityNotFoundException("Category");


            kategorija.Naziv = request.Naziv;
            kategorija.ModifiedOn = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
