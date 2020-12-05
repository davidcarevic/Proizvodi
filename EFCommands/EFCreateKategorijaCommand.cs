using Application.Commands;
using Application.DTO;
using System.Linq;
using Domain;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using EFDataAccess;

namespace EFCommands
{
    public class EFCreateKategorijaCommand: BaseEFCommand, ICreateKategorijaCommand
    {

        public EFCreateKategorijaCommand(ProizvodiContext context) : base(context)
        { }

        public void Execute(CreateKategorijaDTO request) {
            if (_context.Kategorijas.Any(k => k.Naziv.ToLower().Contains(request.Naziv.ToLower())))
            {
                throw new EntityAlreadyExistsException("This category ");
            }

            _context.Kategorijas.Add(new Kategorija{
                Naziv = request.Naziv,
                ModifiedOn = null
            });

            _context.SaveChanges();
        }
    }
}
