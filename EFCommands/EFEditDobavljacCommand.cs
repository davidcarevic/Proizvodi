using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFEditDobavljacCommand : BaseEFCommand, IEditDobavljacCommand
    {
        public EFEditDobavljacCommand(ProizvodiContext context) : base(context) { }

        public void Execute(EditDobavljacDTO request)
        {
            var dob = _context.Dobavljacs.Find(request.Id);

            if (dob == null)
                throw new EntityNotFoundException("Supplier");


            dob.Naziv = request.Naziv;
            dob.ModifiedOn = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
