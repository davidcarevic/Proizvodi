using Application.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO;
using System.Linq;
using Domain;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands
{
    public class EFCreateProizvodjacCommand:BaseEFCommand, ICreateProizvodjacCommand
    {
        public EFCreateProizvodjacCommand(ProizvodiContext context) : base(context)
        { }

        public void Execute(CreateProizvodjacDTO request) {
            if (_context.Proizvodjacs.Any(k => k.Naziv.ToLower().Contains(request.Naziv.ToLower())))
            {
                throw new EntityAlreadyExistsException("This maker ");
            }

            _context.Proizvodjacs.Add(new Proizvodjac
            {
                Naziv = request.Naziv,
                ModifiedOn = null
            });

            _context.SaveChanges();
        }

    }
}
