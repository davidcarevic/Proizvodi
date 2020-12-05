using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteProizvodjacCommand:BaseEFCommand, IDeleteProizvodjacCommand
    {
        public EFDeleteProizvodjacCommand(ProizvodiContext context) : base(context) { }

        public void Execute(int request) {
            var item = _context.Proizvodjacs.Find(request);
            if (item == null)
                throw new EntityNotFoundException("Maker");

            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
