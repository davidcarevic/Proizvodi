using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteProizvodCommand:BaseEFCommand, IDeleteProizvodCommand
    {
        public EFDeleteProizvodCommand(ProizvodiContext context) : base(context) { }

        public void Execute(int request)
        {
            var item = _context.Proizvods.Find(request);
            if (item == null)
                throw new EntityNotFoundException("Article");

            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
