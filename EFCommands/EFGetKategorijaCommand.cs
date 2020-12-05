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
    public class EFGetKategorijaCommand:BaseEFCommand, IGetKategorijaCommand
    {
        public EFGetKategorijaCommand(ProizvodiContext context) : base(context) { }

        public GetKategorijaDTO Execute(int request)
        {

            var r = _context.Kategorijas.Where(u => u.Id == request).First();

            if (r == null) { throw new EntityNotFoundException("Category"); }

            return new GetKategorijaDTO
            {
                Id = r.Id,
                Naziv = r.Naziv,
                CreatedOn = r.CreatedOn,
                ModifiedOn = r.ModifiedOn



            };
        }
    }
}
