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
    public class EFGetProizvodjacCommand:BaseEFCommand,IGetProizvodjacCommand
    {
        public EFGetProizvodjacCommand(ProizvodiContext context) : base(context) { }

        public GetProizvodjacDTO Execute(int request)
        {

            var r = _context.Proizvodjacs.Where(u => u.Id == request).First();

            if (r == null) { throw new EntityNotFoundException("Maker"); }

            return new GetProizvodjacDTO
            {
                Id = r.Id,
                Naziv = r.Naziv,
                CreatedOn = r.CreatedOn,
                ModifiedOn = r.ModifiedOn



            };
        }
    }
}
