using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteKategorija:BaseEFCommand, IDeleteKategorijaCommand
    {
        public EFDeleteKategorija(ProizvodiContext context) : base(context) { }

        public void Execute(int request) {
            var item = _context.Kategorijas.Find(request);
            if (item == null)
                throw new EntityNotFoundException("Category");

            _context.Remove(item);  // mogao sam soft delete mozda
            _context.SaveChanges();
        }
    }
}
