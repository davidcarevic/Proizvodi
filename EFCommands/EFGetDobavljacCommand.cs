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
    public class EFGetDobavljacCommand:BaseEFCommand, IGetDobavljacCommand
    {
        public EFGetDobavljacCommand(ProizvodiContext context) : base(context) { }

        public GetDobavljacDTO Execute(int request)
        {

            var r = _context.Dobavljacs.Where(u => u.Id == request).First();

            if (r == null) { throw new EntityNotFoundException("Supplier"); }

            return new GetDobavljacDTO
            {
                Id = r.Id,
                Naziv = r.Naziv,
                CreatedOn = r.CreatedOn,
                ModifiedOn = r.ModifiedOn



            };
        }
    }
}
