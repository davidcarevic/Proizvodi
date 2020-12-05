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
    public class EFCreateDobavljacCommand:BaseEFCommand, ICreateDobavljacCommand
    {
        public EFCreateDobavljacCommand(ProizvodiContext context) : base(context)
        { }

        public void Execute(CreateDobavljacDTO request) {
            if (_context.Dobavljacs.Any(k => k.Naziv.ToLower().Contains(request.Naziv.ToLower())))
            {
                throw new EntityAlreadyExistsException("This supplier ");
            }

            _context.Dobavljacs.Add(new Dobavljac
            {
                Naziv = request.Naziv,
                ModifiedOn = null
            });

            _context.SaveChanges();
        }
    }
}
